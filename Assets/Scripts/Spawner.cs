using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrisPieces;
    public Transform spawnPoint;
    public float pieceScale = 1f;
    public float rainbowChance = 0.25f;
    private float timeSinceLastSpawn;
    private float lastSpawnTime = -1f;

    public float spawnWaitTime = 10f; // time to wait before spawning a new piece
    public float timeSinceStartWait = 0f;
   

    public RotateSnapSphere rotsphere = null;

    public GameObject pieceTemplate;
    public GameObject cubeTemplate;

    private List<List<Vector3>> cubeCoordList;

    public float spawnCooldown = 0.5f; // cooldown time in seconds

    private void Start()
    {
        cubeCoordList = new List<List<Vector3>>();
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(-2, 0, 0), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 1), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(1, 0, 1), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(-1, 0, 1), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 0, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 1), new Vector3(-1, 0, 1), new Vector3(0, 0, 0), new Vector3(1, 0, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 0), new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(1, 0, 1)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 1), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(-1, 1, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 1), new Vector3(1, 0, 0), new Vector3(0, 0, 0), new Vector3(1, 1, 0)
        });
        cubeCoordList.Add(new List<Vector3>{
            new Vector3(0, 0, 1), new Vector3(-1, 0, 0), new Vector3(0, 0, 0), new Vector3(0, 1, 0)
        });

        CenterCubeCoords();
        bool waiting = true;
        // Sage Tried adding a timer to see if it would allow the pieces to load and prevent double spawning
        // // Spawn the first piece
        // while(waiting)
        // {
        //     timeSinceStartWait += Time.deltaTime;
        //     if (timeSinceStartWait >= spawnWaitTime)
        //     {
        //         waiting = false;
        //     }
        // }

        SpawnRandomPiece();
    }

    void CenterCubeCoords()
    {
        foreach (List<Vector3> cubeCoords in cubeCoordList) 
        {
            Vector3 minV = Vector3.positiveInfinity;
            Vector3 maxV = Vector3.negativeInfinity;

            foreach (Vector3 v in cubeCoords)
            {
                minV = Vector3.Min(minV, v);
                maxV = Vector3.Max(maxV, v);
            }

            Vector3 midV = ((minV + maxV) / 2.0f);

            for (int i = 0; i < cubeCoords.Count; ++i)
            {
                cubeCoords[i] -= midV; 
            }
        }
    }

    public void SpawnRandomPiece()
    {
        timeSinceLastSpawn = Time.time - lastSpawnTime;
        Debug.Log("Time since last spawn: " + timeSinceLastSpawn);

        // usinh a cooldown to prevent spawning too fast but it is reconmended we halt spawning until contact occurs
        if(timeSinceLastSpawn < spawnCooldown)
        {
            //block spawning if cooldown is not met 
            return;
        }

        if (timeSinceLastSpawn < 0.2f)
        {
            Debug.Log("GAME OVER. PIECES TOP OUT");
            this.enabled = false;
            // wait(10); // wait for 10 seconds before going to end scene
            SceneManager.LoadScene("XREndScene"); // go to end scene if time runs out

            return;
        }

        GameObject newPiece = Instantiate(pieceTemplate, spawnPoint.position - new Vector3(0, 3, 0), Quaternion.identity);
        TetrisPiece newPieceComponent = newPiece.GetComponent<TetrisPiece>();
        newPieceComponent.spawner = this;
        int randomIndex = Random.Range(0, cubeCoordList.Count);
        List<Vector3> cubeCoords = cubeCoordList[randomIndex];

        foreach (Vector3 v in cubeCoords) 
        {
            GameObject newCube = Instantiate(cubeTemplate, newPiece.transform);
            newCube.transform.localPosition = v;
        }

        float rainbowRoll = Random.Range(0f, 1f);
        if (rainbowRoll <= rainbowChance)
        {
            newPieceComponent.MakeRainbow();
        }
        else
        {
            int randomColor = Random.Range(0, newPieceComponent.ColorCount());
            newPieceComponent.SetPieceColor(randomColor);
        }

        newPiece.transform.localScale = new Vector3(pieceScale, pieceScale, pieceScale);

        lastSpawnTime = Time.time;
        rotsphere.ResetRotation();
    }
}