using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChildTrigger : MonoBehaviour
{
    [HideInInspector] public bool isAfterDoor;

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == 9)
        {
            isAfterDoor = true;
        }
    }
    
    public void ResetRaise()
    {
        isAfterDoor = false;
    }

}
