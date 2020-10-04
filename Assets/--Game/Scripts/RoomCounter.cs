using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class RoomCounter : MonoBehaviour
{
    public uint roomNumber;
    public TextMeshProUGUI roomCounterUI;

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == 9)
            roomCounterUI.text = roomNumber.ToString();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.layer == 9)
            roomCounterUI.text = "";
    }
}
