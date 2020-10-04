using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Credit : MonoBehaviour
{
    public int speed;
    [Header("Menu")]
    public string returnMainMenu;

    private bool isRolling = true;
    private bool sceneChange = true;

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        Time.timeScale = 1;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown(KeyCode.Space))
        {
            sceneChange = false;
            SceneManager.LoadScene(returnMainMenu);
        }

        if (isRolling && sceneChange)
            transform.Translate(0, speed * Time.deltaTime, 0);
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
