using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public string nameLevel;
    public string creditsSceneName;
    public Text timerText;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Confined;
        Cursor.visible = true;
        Time.timeScale = 1;
        TransitionController.instance?.FadeOut();
        UpdateTimerText();
    }

    public void UpdateTimerText()
    {
        if(GeneralCountDown.instance != null)
        {
            GeneralCountDown.instance.text = timerText;
            GeneralCountDown.instance.SetTimerTextOnMainMenu();
        }
    }

    public void PlayGame()
    {
        Time.timeScale = 1;
        TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(nameLevel));
    }

    public void PlayCredits()
    {
        Time.timeScale = 1;
        TransitionController.instance?.FadeIn(() => SceneManager.LoadScene(creditsSceneName));
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
