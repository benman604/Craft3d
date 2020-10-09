using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OnClick : MonoBehaviour
{
    public string sceneName;
    public Text btnText;

    void Start()
    {
        Button btn = gameObject.GetComponent<Button>();
        btn.onClick.AddListener(GoToScene);
    }

    void GoToScene()
    {
        SceneManager.LoadScene(sceneName);
        btnText.text = "Loading...";
    }
}
