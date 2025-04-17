using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPiece : MonoBehaviour
{
    public Spawner spawner = null;
    private Transform baseContainer = null;
    private bool setPiece = false;
    private float despawnHeight = -5f;

    private Outline outline = null;

    [SerializeField] private Color outlineColor = Color.white;
    [SerializeField, Range(0f, 10f)] private float outlineWidth = 5f;
    
    private static Material[] materials = {};
    public int color = 0;
    private HashSet<GameObject> touching = new HashSet<GameObject>();
    
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
            };
        }
    }

    void Start()
    {
        // spawner = FindObjectOfType<Spawner>();
        baseContainer = GameObject.Find("BaseContainer")?.transform;

        ApplyOutline();
    }

    private void Update()
    {
        if (transform.position.y < despawnHeight)
        {
            Destroy(gameObject);
            if(!setPiece)
                spawner.SpawnRandomPiece();
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("base") || other.gameObject.CompareTag("piece") || other.gameObject.CompareTag("wall"))
        {
            if (!setPiece){
                spawner.SpawnRandomPiece();
                transform.SetParent(baseContainer, true);
                RemoveOutline();
                setPiece = true;
            }
        }

        if (other.gameObject.CompareTag("piece"))
        {
            TetrisPiece otherpiece = other.gameObject.GetComponent<TetrisPiece>();
            if (otherpiece.color == color)
            {
                touching.Add(other.gameObject);

                // This method only works because pieces are deleted in groups of three
                // Can be made more complex
                if (touching.Count >= 2)
                {
                    foreach (GameObject go in touching)
                    {
                        Destroy(go);
                    }
                    Destroy(gameObject);
                }
            }
        }
    }

    void OnCollisionExit(Collision other)
    {
        if (other.gameObject.CompareTag("piece"))
        {
            touching.Remove(other.gameObject);
        }
    }

    public int ColorCount()
    {
        return materials.Length;
    }

    public void SetPieceColor(int ind)
    {
        if (ind >= ColorCount())
            return;
        
        color = ind;
        foreach (Transform child in transform)
        {
            var renderer = child.GetComponent<Renderer>();
            renderer.material = materials[ind];
        }
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