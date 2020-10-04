using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{

    public GameObject pauseMenu;
    [HideInInspector] public GameObject crosshair;

    public string mainMenuSceneName;

    public static PauseMenu instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Start()
    {
        if(GameObject.Find("Crosshair") != null)
        {
            crosshair = GameObject.Find("Crosshair");
        }
    }

    public void ResumeGame()
    {
        PlayerController.instance.isPaused = false;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenu.SetActive(false);
        crosshair.SetActive(true);
        GameManager.instance.Pause(false);
    }

    public void RetryLevel()
    {
        GameManager.instance.Pause(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void QuitToMenu()
    {
        SceneManager.LoadScene(mainMenuSceneName);
    }
}
