using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]
    public bool isActivate = false;

    private uint count = 0;

    private void OnTriggerEnter(Collider other)
    {
        count++;
        isActivate = true;
    }

    private void OnTriggerExit(Collider other)
    {
        count--;
        if (count == 0)
            isActivate = false;
    }
}
