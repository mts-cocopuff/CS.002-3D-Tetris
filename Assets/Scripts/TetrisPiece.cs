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
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.CompareTag("base") || other.gameObject.CompareTag("piece"))
        {
            if (!setPiece){
                spawner.SpawnRandomPiece();
                transform.SetParent(baseContainer, true);
                RemoveOutline();
                setPiece = true;
            }
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