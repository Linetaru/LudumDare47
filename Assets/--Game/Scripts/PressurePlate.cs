using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressurePlate : MonoBehaviour
{
    [HideInInspector]
    public bool isActivate = false;

    public List<GameObject> goOnPressurePlate = new List<GameObject>();

    private void FixedUpdate()
    {
        for(int i = 0; i < goOnPressurePlate.Count; i++)
        {
            if(goOnPressurePlate[i] == null)
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
        if (goOnPressurePlate.Count != 0)
        {
            if(!goOnPressurePlate.Contains(other.gameObject))
            {
                goOnPressurePlate.Add(other.gameObject);
                isActivate = true;
            }
        }
        else
        {
            goOnPressurePlate.Add(other.gameObject);
            isActivate = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (goOnPressurePlate.Contains(other.gameObject))
        {
            goOnPressurePlate.Remove(other.gameObject);
        }

        if (goOnPressurePlate.Count == 0)
        {
            isActivate = false;
        }
    }
}
