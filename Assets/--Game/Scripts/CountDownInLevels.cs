using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CountDownInLevels : MonoBehaviour
{
    public static CountDownInLevels instance;

    private Canvas canvas;

    public Text text;

    private void Awake()
    {
        if (instance == null)
            instance = this;
        else if (instance != null)
            Destroy(this);
    }

    private void Start()
    {
        canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
        GeneralCountDown.instance.text = text;
    }
}
