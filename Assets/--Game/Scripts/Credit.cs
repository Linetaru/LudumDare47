using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public int speed;
    private int speedBase;
    [Header("Menu")]
    public string returnMainMenu;

    private bool isRolling = true;
    private bool sceneChange = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = false;
        Time.timeScale = 1;
        speedBase = speed;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return))
        {
            sceneChange = false;
            SceneManager.LoadScene(returnMainMenu);
        }

        if (isRolling && sceneChange)
        {
            transform.Translate(0, speed * Time.deltaTime, 0);

            if (Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                speed = speedBase * 6;
            }
            else
            {
                speed = speedBase;
            }
        }
        else if (sceneChange)
        {
            sceneChange = false;
            SceneManager.LoadScene(returnMainMenu);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Finish"))
            isRolling = false;
    }
}
