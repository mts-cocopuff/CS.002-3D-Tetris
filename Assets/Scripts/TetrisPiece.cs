using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TetrisPiece : MonoBehaviour
{
    public Spawner spawner = null;

    public TMP_Text scoreText;
    private int speed;
    private Transform baseContainer = null;
    private bool setPiece = false;
    private float despawnHeight = -5f;

    public int fallenPieces = 0;

    private Outline outline = null;

    [SerializeField] private Color outlineColor = Color.white;
    [SerializeField, Range(0f, 10f)] private float outlineWidth = 5f;
    
    private static Material[] materials = {};
    public int color = 0;
    public bool rainbow = false;
    private HashSet<TetrisPiece> touching = new HashSet<TetrisPiece>();
    
    void Awake()
    {
        if (materials.Length == 0)
        {
            materials = new Material[] {
                Resources.Load<Material>("Materials/Blue"),
                Resources.Load<Material>("Materials/Cyan"),
                Resources.Load<Material>("Materials/Green"),
                Resources.Load<Material>("Materials/Orange"),
                Resources.Load<Material>("Materials/Purple"),
                Resources.Load<Material>("Materials/Red"),
                Resources.Load<Material>("Materials/Yellow"),
                Resources.Load<Material>("Materials/Rainbow"),
            };
        }
    }

    void Start()
    {
        // spawner = FindObjectOfType<Spawner>();
        baseContainer = GameObject.Find("BaseContainer")?.transform;
        scoreText = GameObject.Find("Score").GetComponent<TextMeshProUGUI>();
        speed = PlayerPrefs.GetInt("speed", 3);

        ApplyOutline();
    }

    private void Update()
    {
        if (transform.position.y < despawnHeight)
        {
            if(!setPiece) {
                setPiece = true;
                spawner.SpawnRandomPiece();
            }
            Destroy(gameObject);
            fallenPieces++;
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("base") || other.gameObject.CompareTag("piece"))
        {
            if (!setPiece){
                setPiece = true;
                spawner.SpawnRandomPiece();
                transform.SetParent(baseContainer, true);
                RemoveOutline();
            }
        }

        if (other.gameObject.CompareTag("piece"))
        {
            TetrisPiece otherpiece = other.gameObject.GetComponent<TetrisPiece>();
            TouchPiece(otherpiece);
        }
    }

    void TouchPiece(TetrisPiece otherpiece)
    {
        if (!(otherpiece.color == color || otherpiece.rainbow || rainbow))
            return;
        
        touching.Add(otherpiece);

        if (rainbow)
        {
            int[] colorCounts = new int[ColorCount()];
            foreach (TetrisPiece tp in touching)
            {
                if (tp.rainbow)
                {
                    for (int i = 0; i < colorCounts.Length; ++i)
                        colorCounts[i] += 1;
                }
                else
                {
                    colorCounts[tp.color] += 1;
                }
            }

            bool willDelete = false;
            foreach (int num in colorCounts)
            {
                if (num >= 2)
                {
                    willDelete = true;
                    break;
                }
            }

            if (willDelete)
            {
                foreach (TetrisPiece tp in touching)
                    if (tp.rainbow || colorCounts[tp.color] >= 2)
                        Destroy(tp.gameObject);
                Destroy(gameObject);
                
                scoreText.text = (int.Parse(scoreText.text) + (50 * speed)).ToString();
            }
        }
        else if (touching.Count >= 2)
        {
            foreach (TetrisPiece tp in touching)
                Destroy(tp.gameObject);
            Destroy(gameObject);
            
            scoreText.text = (int.Parse(scoreText.text) + (75 * speed)).ToString();
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("piece"))
        {
            touching.Remove(other.gameObject.GetComponent<TetrisPiece>());
        }
    }

    public int ColorCount()
    {
        return 7;
    }

    private void UpdateMaterial()
    {
        int ind = color % 7;
        if (rainbow)
            ind = 7;

        foreach (Transform child in transform)
        {
            var renderer = child.GetComponent<Renderer>();
            renderer.material = materials[ind];
        }
    }

    public void SetPieceColor(int ind)
    {
        color = ind;
        
        UpdateMaterial();
    }

    public void MakeRainbow()
    {
        color = 0;
        rainbow = true;
        
        UpdateMaterial();
    }

    private void ApplyOutline()
    {
        outline = gameObject.AddComponent<Outline>();
        outline.OutlineMode = Outline.Mode.OutlineAll;
        outline.OutlineColor = outlineColor;
        outline.OutlineWidth = outlineWidth;
        outline.enabled = true;
    }

    private void RemoveOutline()
    {
        outline.enabled = false;
    }
}