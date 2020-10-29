using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SetFov : MonoBehaviour
{
    public TextMeshProUGUI text;
    public Slider slider;

    private void Start()
    {
        Init();
    }

    public void Init()
    {
        slider.value = PlayerPrefs.GetFloat("playerFov", 80f);
        UpdateText();
    }

    public void SetPlayerFov()
    {
        PlayerPrefs.SetFloat("playerFov", Mathf.Round(slider.value));
        UpdateText();
    }

    public void UpdateText()
    {
        text.text = "" + Mathf.Round(slider.value);
    }
}
