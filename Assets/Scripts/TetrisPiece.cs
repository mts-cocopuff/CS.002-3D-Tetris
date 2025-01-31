using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetrisPiece : MonoBehaviour
{
    private Spawner spawner;
    private Transform baseContainer;
    private bool setPiece = false;
    private float despawnHeight = -5f;
    
    void Start()
    {
        spawner = FindObjectOfType<Spawner>();
        baseContainer = GameObject.Find("BaseContainer")?.transform;
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
            if (setPiece == false){
                spawner.SpawnRandomPiece();
                transform.SetParent(baseContainer, true);
                setPiece = true;
            }
        }
    }
}