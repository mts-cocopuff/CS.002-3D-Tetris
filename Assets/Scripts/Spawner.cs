using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrisPieces;
    public Transform spawnPoint;

    private void Start()
    {
        SpawnRandomPiece();
    }

    public void SpawnRandomPiece()
    {
        if (tetrisPieces.Length == 0) return;

        int randomIndex = Random.Range(0, tetrisPieces.Length);
        Instantiate(tetrisPieces[randomIndex], spawnPoint.position, Quaternion.identity);
    }
}