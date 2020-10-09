using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InitilizationSphere : MonoBehaviour
{
    public GameObject floor;
    public GameObject corner;
    public GameObject glass;

    public float floorx = 10;
    public float floorz = 10;
    public float height = 60;
    public float floorcount = 10;
    public float floortoceling = 5;

    void Start()
    {
        floorx = PreRectGenStorage.width;
        floorz = PreRectGenStorage.depth;
        floorcount = PreRectGenStorage.floors;
        floortoceling = PreRectGenStorage.floortoceling;

        for (float i = -1; i <= floorcount*floortoceling; i += floortoceling)
        {
            CreateFloor(i);
        }

        for(float j = -1; j <= floorcount * floortoceling; j++)
        {
            CreateCorners(j);
            CreateWindows(j);
        }
    }

    void CreateFloor(float y)
    {
        for (float x = -floorx; x <= floorx; x++)
        {
            for (float z = -floorz; z <= floorz; z++)
            {
                GameObject newblock = Instantiate(floor, new Vector3(x, y, z), Quaternion.identity);
                newblock.gameObject.name = "block";
            }
        }
    }

    void CreateCorners(float y)
    {
        GameObject a = Instantiate(corner, new Vector3(floorx, y, -floorz), Quaternion.identity);
        GameObject b = Instantiate(corner, new Vector3(floorx, y, floorz), Quaternion.identity);
        GameObject c = Instantiate(corner, new Vector3(-floorx, y, -floorz), Quaternion.identity);
        GameObject d = Instantiate(corner, new Vector3(-floorx, y, floorz), Quaternion.identity);

        a.gameObject.name = "block";
        b.gameObject.name = "block";
        c.gameObject.name = "block";
        d.gameObject.name = "block";
    }

    void CreateWindows(float y)
    {
        for(float z = -floorz; z <= floorz; z++)
        {
            GameObject a = Instantiate(glass, new Vector3(floorx, y, z), Quaternion.identity);
            GameObject b = Instantiate(glass, new Vector3(-floorx, y, -z), Quaternion.identity);

            a.gameObject.name = "block";
            b.gameObject.name = "block";
        }

        for (float x = -floorx; x <= floorx; x++)
        {
            GameObject c = Instantiate(glass, new Vector3(x, y, floorz), Quaternion.identity);
            GameObject d = Instantiate(glass, new Vector3(-x, y, -floorz), Quaternion.identity);

            c.gameObject.name = "block";
            d.gameObject.name = "block";
        }
    }
}
