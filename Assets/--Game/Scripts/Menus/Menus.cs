using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using TMPro;

public class Menus : MonoBehaviour
{
    public TextMeshProUGUI textLevelStart;

    private Tween tween;
    void Start()
    {
        tween = textLevelStart.DOColor(Color.white, 2).OnComplete(() => textLevelStart.DOColor(new Color(1, 1, 1, 0), 2));
    }
}
