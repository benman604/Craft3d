using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilizationPyramid : MonoBehaviour
{
    public GameObject rock;

    void Start()
    {
        for(float i = 25; i >= 0; i--)
        {
            CreatePlane(i, 25-i);
        }
    }

    void CreatePlane(float y, float size)
    {
        for (float x = -size; x <= size; x++)
        {
            for (float z = -size; z <= size; z++)
            {
                GameObject newblock = Instantiate(rock, new Vector3(x, y, z), Quaternion.identity);
                newblock.gameObject.name = "block";
            }
        }
    }
}
