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

    private bool isOpen = false;
    private Tween tween;
    /*private float maxPosY;
    private float minPosY;*/

    private void Start()
    {
        tween = null;
    }

    private void Update()
    {
        CheckDoorPlates();
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

    private void StartOpenDoor()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        if (tween != null)
            if (tween.IsPlaying())
                tween.Kill();

        tween = gameObject.GetComponent<MeshRenderer>().material.DOFloat(1f, "_DissolveAmount", durationToDisappear);
    }

    private void StartCloseDoor()
    {
        gameObject.GetComponent<Collider>().enabled = true;

        if (tween != null)
            if (tween.IsPlaying())
                tween.Kill();

        tween = gameObject.GetComponent<MeshRenderer>().material.DOFloat(0f, "_DissolveAmount", durationToAppear);
    }
}
