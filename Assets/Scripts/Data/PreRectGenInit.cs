using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PreRectGenInit : MonoBehaviour
{
    public Text width;
    public Text depth;
    public Text floors;
    public Text floortoceling;

    public Text self;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(Go);
    }

    void Go()
    {
        PreRectGenStorage.width = float.Parse(width.text);
        PreRectGenStorage.depth = float.Parse(depth.text);
        PreRectGenStorage.floors = float.Parse(floors.text);
        PreRectGenStorage.floortoceling = float.Parse(floortoceling.text);

        SceneManager.LoadScene("BuildingGenerator");
        self.text = "Loading...";
    }
}
