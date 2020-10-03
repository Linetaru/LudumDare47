using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Door : MonoBehaviour
{
    public GameObject[] objectsToOpenTheDoor;
    public float durationToDisappear;
    public float durationToAppear;

    private float durToDisappear = 0f;
    private float durToAppear = 0f;

    private bool isOpen = false;
    private Action DoAction;

    private Color colorAlpha;

    private Tween tween;

    private void Start()
    {
        //colorAlpha = gameObject.GetComponent<Renderer>().material.color;
        //DoAction = DoActionVoid;
        tween = null;
    }

    private void Update()
    {
        CheckDoorPlates();
        //DoAction();
    }

    private void CheckDoorPlates()
    {
        bool allActivated = true;
        for (int i = 0; i < objectsToOpenTheDoor.Length; i++)
        {
            if (objectsToOpenTheDoor[i].GetComponent<PressurePlateColor>() != null)
            {
                if (!objectsToOpenTheDoor[i].GetComponent<PressurePlateColor>().isActivate)
                {
                    allActivated = false;
                    break;
                }
            }
            else if (objectsToOpenTheDoor[i].GetComponent<PressurePlate>() != null)
            {
                if (!objectsToOpenTheDoor[i].GetComponent<PressurePlate>().isActivate)
                {
                    allActivated = false;
                    break;
                }
            }
        }
        if (allActivated && !isOpen)
        {
#if UNITY_EDITOR
            Debug.Log("Open the door!");
            StartOpenDoor();
            isOpen = true;
#endif
        }
        else if (!allActivated && isOpen)
        {
#if UNITY_EDITOR
            Debug.Log("Close the door!");
            StartCloseDoor();
            isOpen = false;
#endif
        }
    }

    private void DoActionVoid()
    {
    }

    private void StartOpenDoor()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        //durToDisappear = durationToDisappear - durToAppear;
        //colorAlpha = gameObject.GetComponent<Renderer>().material.color;
        if(tween != null)
            if (tween.IsPlaying())
                tween.Kill();

        tween = gameObject.transform.DOMoveY(gameObject.transform.position.y + 3, durationToDisappear);
    }

    private void OpenDoor()
    {
        durToDisappear -= Time.deltaTime;

        if (durToDisappear <= 0f)
        {
            durToDisappear = 0f;
            DoAction = DoActionVoid;
        }
        else
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color (colorAlpha.r, colorAlpha.g, colorAlpha.b, 0f), colorAlpha, durToDisappear);
    }

    private void StartCloseDoor()
    {
        gameObject.GetComponent<Collider>().enabled = true;
        //durToAppear = durationToAppear - durToDisappear;
        //colorAlpha = gameObject.GetComponent<Renderer>().material.color;
        //DoAction = CloseDoor;
        if (tween != null)
            if (tween.IsPlaying())
                tween.Kill();
        tween = gameObject.transform.DOMoveY(gameObject.transform.position.y - 3, durationToAppear);
    }

    private void CloseDoor()
    {
        durToAppear -= Time.deltaTime;

        if (durToAppear <= 0f)
        {
            durToAppear = 0f;
            DoAction = DoActionVoid;
        }
        else
            gameObject.GetComponent<Renderer>().material.color = Color.Lerp(new Color(colorAlpha.r, colorAlpha.g, colorAlpha.b, 1f), colorAlpha, durToAppear);
    }
}
