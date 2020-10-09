using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Initilization : MonoBehaviour
{
    public GameObject bedrock;
    public GameObject rock;
    public GameObject grass;

    void Start()
    {
        CreatePlane(-1, bedrock);
        CreatePlane(0, rock);
        CreatePlane(1, grass);
    }

    void CreatePlane(float y, GameObject type)
    {
        for (float x=-24.5f; x<=24.5; x++)
        {
            for (float z=-24.5f; z<=24.5f; z++)
            {
                GameObject newblock = Instantiate(type, new Vector3(x, y, z), Quaternion.identity);
                newblock.gameObject.name = "block";
            }
        }
    }
}
