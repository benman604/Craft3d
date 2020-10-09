using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilizationParabola2 : MonoBehaviour
{
    public GameObject block;
    // Start is called before the first frame update
    void Start()
    {
        for (float z = -25f; z <= 25f; z++)
        {
            float height = (Mathf.Pow(z, 2) / 25);
            CreateVerticalSlab(Mathf.Round(height), z);
        }
    }

    void CreateVerticalSlab(float height, float z)
    {
        for (float y = -1; y <= height; y++)
        {
            for (float x = -24.5f; x <= 24.5; x++)
            {
                GameObject newblock = Instantiate(block, new Vector3(x, y, z), Quaternion.identity);
                newblock.gameObject.name = "block";
            }
        }
    }
}
