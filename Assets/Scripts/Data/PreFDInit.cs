using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreFDInit : MonoBehaviour
{
    public Text floors;
    public Text self;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Go);
    }

    void Go()
    {
        PreFDStorage.floors = float.Parse(floors.text);
        SceneManager.LoadScene("FloorDuplicator");
    }
}
