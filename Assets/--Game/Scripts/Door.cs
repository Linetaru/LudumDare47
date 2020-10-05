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
        gameObject.GetComponent<MeshRenderer>().material.SetFloat("_DissolveAmount", 1f);
        StartCloseDoor();
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
            StartOpenDoor();
            isOpen = true;
        }
        else if (!allActivated && isOpen)
        {
            StartCloseDoor();
            isOpen = false;
        }
    }

    private void StartOpenDoor()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.SfxDoor(SoundManager.State.Stop);
            SoundManager.instance.SfxDoor(SoundManager.State.Play);
        }
        gameObject.layer = 12;
        //gameObject.GetComponent<Collider>().enabled = false;

        if (tween != null)
            if (tween.IsPlaying())
                tween.Kill();

        tween = gameObject.GetComponent<MeshRenderer>().material.DOFloat(1f, "_DissolveAmount", durationToDisappear);
    }

    private void StartCloseDoor()
    {
        if (SoundManager.instance != null)
        {
            SoundManager.instance.SfxDoor(SoundManager.State.Stop);
            SoundManager.instance.SfxDoor(SoundManager.State.Play);
        }
        gameObject.layer = 0;
        //gameObject.GetComponent<Collider>().enabled = true;

        if (tween != null)
            if (tween.IsPlaying())
                tween.Kill();

        tween = gameObject.GetComponent<MeshRenderer>().material.DOFloat(0f, "_DissolveAmount", durationToAppear);
    }
}
