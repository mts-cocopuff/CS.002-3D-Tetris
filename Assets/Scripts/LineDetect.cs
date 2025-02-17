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
    public int clearLimit;
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
        List<Collider> cubes = new List<Collider>();
        foreach (Collider c in hitColliders)
        {
            // Checking for cubes by name right now
            if (c.name.Length < 4)
                continue;
            
            string name = c.name.Substring(0, 4);
            if (name != "Cube")
                continue;

            Gravity grav = c.transform.parent.gameObject.GetComponent<Gravity>();
            if (grav != null && grav.IsFalling())
                continue;

            cubes.Add(c);
        }
        debugText.text = "Detected cubes: " + cubes.Count.ToString() + "\nLimit: " + clearLimit.ToString();
        if (cubes.Count >= clearLimit)
        {
            clearCubes(cubes);
        }
    }

    private void clearCubes(List<Collider> cubes)
    {
        foreach (Collider c in cubes)
        {
            // Delete parent if empty
            Transform parent = c.transform.parent;

            Destroy(c);
            Destroy(c.gameObject);
            if (parent.childCount == 0)
            {
                Destroy(parent.gameObject);
            }
            else
            {
                Rigidbody rb = parent.gameObject.GetComponent<Rigidbody>();
                rb?.WakeUp();
                rb?.ResetCenterOfMass();
            }
        }
    }

    void OnDrawGizmosSelected()
    {
        // Draw a yellow cube at the transform position
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireCube(center, extends);
    }
}
