using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using PackageCreator.Event;

public class RoomReset : MonoBehaviour
{
    private Vector3 startPosition;
    private Quaternion startRotation;

    public GameObject player;

    public GameEvent resetEvent;

    // Start is called before the first frame update
    void Start()
    {
        startPosition = player.transform.position;
        startRotation = player.transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {

    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
            ResetAllRoom();
    }

    void ResetAllRoom()
    {
        resetEvent.Raise();
        player.transform.position = startPosition;
        player.transform.rotation = startRotation;
    }
}
