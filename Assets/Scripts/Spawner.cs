using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] tetrisPieces;
    public Material[] tetrisMaterials;
    public Transform spawnPoint;
    private float timeSinceLastSpawn;
    private float lastSpawnTime = -1f;

    public RotateSnapSphere rotsphere = null;

    public GameObject pieceTemplate;
    public GameObject cubeTemplate;

    private List<List<Vector3>> cubeCoordList;

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

    Material RandomMaterial()
    {
        int randomIndex = Random.Range(0, tetrisMaterials.Length);
        return tetrisMaterials[randomIndex];
    }

    public void SpawnRandomPiece()
    {
        timeSinceLastSpawn = Time.time - lastSpawnTime;
        Debug.Log("Time since last spawn: " + timeSinceLastSpawn);

        if (timeSinceLastSpawn < 0.2f)
        {
            Debug.Log("GAME OVER. PIECES TOP OUT");
            this.enabled = false;
            return;
        }

        GameObject newPiece = Instantiate(pieceTemplate, spawnPoint.position - new Vector3(0, 3, 0), Quaternion.identity);
        newPiece.GetComponent<TetrisPiece>().spawner = this;
        int randomIndex = Random.Range(0, cubeCoordList.Count);
        List<Vector3> cubeCoords = cubeCoordList[randomIndex];

        foreach (Vector3 v in cubeCoords) 
        {
            GameObject newCube = Instantiate(cubeTemplate, newPiece.transform);
            newCube.transform.localPosition = v;
        }

        newPiece.GetComponent<TetrisPiece>().SetPieceMaterial(RandomMaterial());

        lastSpawnTime = Time.time;
        rotsphere.ResetRotation();
    }
}