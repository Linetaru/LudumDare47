using System.Collections;
using System.Collections.Generic;
using UnityEditorInternal;
using UnityEngine;

public class PressurePlateColor : MonoBehaviour
{
    public enum CubeColor
    {
        Yellow,
        Red,
        Green,
        Blue
    };
    public CubeColor CubeColorToActive;

    [HideInInspector]
    public bool isActivate = false;

    private void OnTriggerEnter(Collider other)
    {
        if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
            || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
            || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
            || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue))
        {
            isActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if ((other.CompareTag("YellowCube") && CubeColorToActive == CubeColor.Yellow)
            || (other.CompareTag("RedCube") && CubeColorToActive == CubeColor.Red)
            || (other.CompareTag("GreenCube") && CubeColorToActive == CubeColor.Green)
            || (other.CompareTag("BlueCube") && CubeColorToActive == CubeColor.Blue))
        {
            isActivate = false;
        }
    }
}
