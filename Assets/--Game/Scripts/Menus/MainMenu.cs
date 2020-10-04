using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameLevel;
    public string creditsSceneName;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1;
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(nameLevel);
    }

    public void PlayCredits()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(creditsSceneName);
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
