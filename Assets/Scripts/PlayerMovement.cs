using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController cc;
    public float speed = 13f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float y = 0;
        float z = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.R)) { y = 1; }
        if (Input.GetKey(KeyCode.F)) { y = -1; }

        Vector3 move = transform.right * x + transform.forward * z + new Vector3(0f, y, 0f);
        cc.Move(move * speed * Time.deltaTime);

        if (Input.GetKeyDown(KeyCode.X))
        {
            SceneManager.LoadScene("Title");
            Cursor.lockState = CursorLockMode.None;
        }
    }
}
