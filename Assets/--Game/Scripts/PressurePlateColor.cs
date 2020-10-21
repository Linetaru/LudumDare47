using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlateColor : MonoBehaviour
{
    public enum CubeColor
    {
        Yellow,
        Red,
        Green,
        Blue,
        Temporal
    };
    public CubeColor CubeColorToActive;

    [HideInInspector]
    public bool isActivate = false;

    //private void OnTriggerEnter(Collider other)
    //{
    //    if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
    //        || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
    //        || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
    //        || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue)
    //        || (other.CompareTag("TemporalCube") && CubeColorToActive == CubeColor.Temporal))
    //    {
    //        isActivate = true;
    //        if (SoundManager.instance != null)
    //        {
    //            SoundManager.instance.SfxButtonOn(SoundManager.State.Stop);
    //            SoundManager.instance.SfxButtonOn(SoundManager.State.Play);
    //        }
    //    }
    //}

    //private void OnTriggerExit(Collider other)
    //{
    //    if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
    //        || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
    //        || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
    //        || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue)
    //        || (other.CompareTag("TemporalCube") && CubeColorToActive == CubeColor.Temporal))
    //    {
    //        isActivate = false;
    //        if (SoundManager.instance != null)
    //        {
    //            SoundManager.instance.SfxButtonOff(SoundManager.State.Stop);
    //            SoundManager.instance.SfxButtonOff(SoundManager.State.Play);
    //        }
    //    }
    //}

    public List<GameObject> goOnPressurePlate = new List<GameObject>();

    private void FixedUpdate()
    {
        for (int i = 0; i < goOnPressurePlate.Count; i++)
        {
            if (goOnPressurePlate[i] == null)
            {
                goOnPressurePlate.RemoveAt(i);
            }
        }
        if (goOnPressurePlate.Count == 0)
        {
            isActivate = false;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
            || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
            || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
            || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue)
            || (other.CompareTag("TemporalCube") && CubeColorToActive == CubeColor.Temporal))
        {
            if (goOnPressurePlate.Count != 0)
            {
                if (!goOnPressurePlate.Contains(other.gameObject))
                {
                    goOnPressurePlate.Add(other.gameObject);
                    isActivate = true;
                    if (SoundManager.instance != null)
                    {
                        SoundManager.instance.SfxButtonOn(SoundManager.State.Stop);
                        SoundManager.instance.SfxButtonOn(SoundManager.State.Play);
                    }
                }
            }

            else
            {
                goOnPressurePlate.Add(other.gameObject);
                isActivate = true;
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.SfxButtonOn(SoundManager.State.Stop);
                    SoundManager.instance.SfxButtonOn(SoundManager.State.Play);
                }
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
            || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
            || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
            || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue)
            || (other.CompareTag("TemporalCube") && CubeColorToActive == CubeColor.Temporal))
        {
            if (goOnPressurePlate.Contains(other.gameObject))
            {
                goOnPressurePlate.Remove(other.gameObject);
                if (SoundManager.instance != null)
                {
                    SoundManager.instance.SfxButtonOff(SoundManager.State.Stop);
                    SoundManager.instance.SfxButtonOff(SoundManager.State.Play);
                }
            }

            if (goOnPressurePlate.Count == 0)
            {
                isActivate = false;
            }
        }
    }
}
