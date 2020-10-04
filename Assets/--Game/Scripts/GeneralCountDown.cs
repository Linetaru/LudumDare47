using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GeneralCountDown : MonoBehaviour
{
    public static GeneralCountDown instance;

    [HideInInspector] public Text text;

    private float timer;

    [HideInInspector] public bool isTimerNeedtoBeActif;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this.gameObject);

        DontDestroyOnLoad(this.gameObject);
    }

    private void Start()
    {
        timer = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "MainMenu" || SceneManager.GetActiveScene().name == "Credits")
        {
            isTimerNeedtoBeActif = false;
        }
        else if(SceneManager.GetActiveScene().name != "MainMenu" && SceneManager.GetActiveScene().name != "Credits" && !isTimerNeedtoBeActif)
        {
            isTimerNeedtoBeActif = true;
        }

        if (isTimerNeedtoBeActif)
        {
            timer += Time.deltaTime * 1;
            string hours = Mathf.Floor((timer % 216000) / 3600).ToString("00");
            string minutes = Mathf.Floor((timer % 3600) / 60).ToString("00");
            string seconds = (timer % 60).ToString("00");
            if(text != null)
                text.text = hours + ":" + minutes + ":" + seconds;
        }
    }

    private void Reset()
    {
        timer = 0;
    }
}
