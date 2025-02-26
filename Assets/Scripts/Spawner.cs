using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrisPieces;
    public Transform spawnPoint;
    private float timeSinceLastSpawn;
    private float lastSpawnTime = -1f;

    private void Start()
    {
        SpawnRandomPiece();
    }

    public void SpawnRandomPiece()
    {
        timeSinceLastSpawn = Time.time - lastSpawnTime;

        if (timeSinceLastSpawn < 0.2f)
        {
            Debug.Log("GAME OVER. PIECES TOP OUT");
            this.enabled = false;
            return;
        }

        if (tetrisPieces.Length == 0) return;

        int randomIndex = Random.Range(0, tetrisPieces.Length);
        Instantiate(tetrisPieces[randomIndex], spawnPoint.position, Quaternion.identity);

        lastSpawnTime = Time.time;
    }
}