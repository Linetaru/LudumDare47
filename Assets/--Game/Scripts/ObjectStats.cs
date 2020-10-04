using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector] public bool isOnHand;

    private void Start()
    {
        startPosition = this.transform.position;
        isOnHand = false;
    }

    public void ResetObject()
    {
        if(!isOnHand)
            this.transform.position = startPosition;
    }
}
