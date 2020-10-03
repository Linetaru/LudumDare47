using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject[] objectsToOpenTheDoor;

    private bool isOpen = false;
    void Update()
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
            isOpen = true;
#endif
        }
        else if (!allActivated && isOpen)
        {
#if UNITY_EDITOR
            Debug.Log("Close the door!");
            isOpen = false;
#endif
        }
    }
}
