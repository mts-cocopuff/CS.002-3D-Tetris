using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Curve : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Mesh mesh = GetComponent<MeshFilter>().mesh;
        Vector3[] vertices = mesh.vertices;

        for (int i = 0; i < vertices.Length; i++)
        {
            Vector3 vertex = vertices[i];
            float radius = 5.0f; // Adjust the radius as needed
            float angle = vertex.x / radius;
            float newX = Mathf.Sin(angle) * radius;
            float newZ = Mathf.Cos(angle) * radius - radius;

            vertices[i] = new Vector3(newX, vertex.y, newZ);
        }

        mesh.vertices = vertices;
        mesh.RecalculateNormals();
        mesh.RecalculateBounds();
    }
}
