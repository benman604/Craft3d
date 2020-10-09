using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;

public class FloorDuplicator : MonoBehaviour
{
    public ArrayList arrx = new ArrayList();
    public ArrayList arry = new ArrayList();
    public ArrayList arrz = new ArrayList();
    public ArrayList arrc = new ArrayList();

    float topy = 0;
    public float floors = 5;

    public Camera FpsCam;
    public float range = 15f;
    public GameObject block;
    public Text colorSelectionDisplay;

    Color selectedColor = Color.gray;

    private void Start()
    {
        floors = PreFDStorage.floors;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Cast(true);
        }
        if (Input.GetMouseButtonDown(1))
        {
            Cast(false);
        }

        /*
           Color Key:
           0: Grey
           1: Black
           2: White
           3: Red
           4: Green
           5: Blue
           6: Yellow
        */
        if (Input.GetKeyDown(KeyCode.Alpha0)) { selectedColor = Color.gray; UpdateSelction("Gray"); }
        if (Input.GetKeyDown(KeyCode.Alpha1)) { selectedColor = Color.black; UpdateSelction("Black"); }
        if (Input.GetKeyDown(KeyCode.Alpha2)) { selectedColor = Color.white; UpdateSelction("White"); }
        if (Input.GetKeyDown(KeyCode.Alpha3)) { selectedColor = Color.red; UpdateSelction("Red"); }
        if (Input.GetKeyDown(KeyCode.Alpha4)) { selectedColor = Color.green; UpdateSelction("Green"); }
        if (Input.GetKeyDown(KeyCode.Alpha5)) { selectedColor = Color.blue; UpdateSelction("Blue"); }
        if (Input.GetKeyDown(KeyCode.Alpha6)) { selectedColor = Color.yellow; UpdateSelction("Yellow"); }
        if (Input.GetKeyDown(KeyCode.Alpha7)) { selectedColor = new Color(1, 1, 1, 0.5f); UpdateSelction("Glass"); }

        if (Input.GetKeyDown(KeyCode.P)) { Duplicate(floors-1); }
    }

    void Cast(bool create)
    {
        RaycastHit hit;
        if (Physics.Raycast(FpsCam.transform.position, FpsCam.transform.forward, out hit, range))
        {
            if (create && hit.transform.gameObject.name == "block")
            {
                Vector3 newPos = hit.transform.position + hit.normal;
                GameObject newblock = Instantiate(block, newPos, Quaternion.identity);
                newblock.gameObject.name = "block";
                newblock.GetComponent<Renderer>().material.color = selectedColor;

                if(newblock.gameObject.transform.position.y > topy) { topy = newblock.gameObject.transform.position.y; }

                arrx.Add(newPos.x);
                arry.Add(newPos.y);
                arrz.Add(newPos.z);
                arrc.Add(selectedColor);
            }
            if (!create && hit.transform.gameObject.name == "block")
            {
                Destroy(hit.transform.gameObject);
            }
        }
    }

    void UpdateSelction(string name)
    {
        colorSelectionDisplay.text = name + " Selected";
    }

    void Duplicate(float floors)
    {
        for(float y = topy; y <= floors*topy; y += topy-1)
        {
            for(int i = 0; i < arrx.Count; i++)
            {
                Vector3 pos = new Vector3(Convert.ToSingle(arrx[i]), Convert.ToSingle(arry[i])+y-1, Convert.ToSingle(arrz[i]));
                GameObject newblock = Instantiate(block, pos, Quaternion.identity);
                newblock.gameObject.name = "block";
                newblock.GetComponent<Renderer>().material.color = (Color) arrc[i];
            }
        }
    }
}
