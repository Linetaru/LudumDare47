using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

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

    public void Quit()
    {
        //Stop le jeu sur l'editeur quand on appelle la fonction
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        //Sinon quitte l'application si c'est une build
        Application.Quit();
    }

    public void Pause(bool pause)
    {
        if (!pause)
            Time.timeScale = 0;
        else
            Time.timeScale = 1;
    }

    public void MyLoadScene(string nameScene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
    }
}
