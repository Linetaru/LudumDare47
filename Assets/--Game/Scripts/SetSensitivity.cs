using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetSensitivity : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        slider.value = PlayerPrefs.GetFloat("mouseSensitivity", 1f);
        UpdateText();
    }

    public void SetPlayerSensitivity()
    {
        PlayerPrefs.SetFloat("mouseSensitivity", slider.value);
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "" + Mathf.Round(slider.value * 1000) / 1000;
    }
}
