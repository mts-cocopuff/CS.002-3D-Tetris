 /*
 * Feb 10 2025
 * Rebecca Klump
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LineDetect : MonoBehaviour
{
    public Text debugText;
    Vector3 center;
    Vector3 extends;
    // Start is called before the first frame update
    void Start()
    {
        center = new Vector3(0.0f, 1.0f, 0.0f);
        extends = new Vector3(15.0f, 0.5f, 15.0f);
    }

    // Update is called once per frame
    void Update()
    {
        LayerMask layermask = ~0;
        Collider[] hitColliders = Physics.OverlapBox(center, extends / 2, Quaternion.identity, layermask);
        int count = 0;
        foreach (Collider c in hitColliders)
        {
            // Checking for cubes by name right now
            if (c.name.Length >= 4)
            {
                string name = c.name.Substring(0, 4);
                if (name == "Cube")
                {
                    count++;
                }
            }
        }
        debugText.text = "Detected cubes: " + count.ToString();
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, extends);
    }
}
