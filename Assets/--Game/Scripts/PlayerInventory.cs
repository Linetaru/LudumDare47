using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerInventory : MonoBehaviour
{
    public List<GameObject> inventoryObjects;

    [Header("Hands")]
    public Transform leftHand;
    public Transform rightHand;

    private GameObject leftHandGo;
    private GameObject rightHandGo;

    [Header("Raycast Settings")]
    public LayerMask layerMaskObject;
    public LayerMask layerMaskNoPlayer;
    RaycastHit hit;

    public int maxDistanceRayCast;

    const string left = "left";
    const string right = "right";

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            if(leftHandGo != null)
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistanceRayCast, layerMaskNoPlayer))
                {
                    DropObjectInHand(left, hit.point);
                }
            }
            else
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistanceRayCast, layerMaskObject))
                {
                    AddObjectInInventory(left, hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (rightHandGo != null)
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistanceRayCast, layerMaskNoPlayer))
                {
                    DropObjectInHand(right, hit.point);
                }
            }
            else
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, maxDistanceRayCast, layerMaskObject))
                {
                    AddObjectInInventory(right, hit.collider.gameObject);
                }
            }
        }
    }

    public void AddObjectInInventory(string hand,GameObject go)
    {
        switch(hand)
        {
            case left:
                inventoryObjects.Add(go);
                if (inventoryObjects.Contains(hit.collider.gameObject))
                    SetObjectInHand(left, hit.collider.gameObject);
                break;

            case right:
                inventoryObjects.Add(go);
                if (inventoryObjects.Contains(hit.collider.gameObject))
                    SetObjectInHand(right, hit.collider.gameObject);
                break;

            default:
                break;
        }
    }

    public void DropObjectInHand(string hand, Vector3 point)
    {
        if (hand == left)
        {
            leftHandGo.transform.parent = null;
            inventoryObjects.Remove(leftHandGo);
            leftHandGo.transform.DOMove(point + new Vector3(0, 0.5f, 0), 0.25f) ;
            leftHandGo.GetComponent<Rigidbody>().useGravity = true;
            leftHandGo.GetComponent<BoxCollider>().enabled = true;
            leftHandGo.GetComponent<ObjectStats>().isOnHand = false;
            leftHandGo = null;
        }
        else
        {
            rightHandGo.transform.parent = null;
            inventoryObjects.Remove(rightHandGo);
            rightHandGo.transform.DOMove(point + new Vector3(0, 0.5f, 0), 0.25f);
            rightHandGo.GetComponent<Rigidbody>().useGravity = true;
            rightHandGo.GetComponent<BoxCollider>().enabled = true;
            rightHandGo.GetComponent<ObjectStats>().isOnHand = false;
            rightHandGo = null;
        }
    }

    public void SetObjectInHand(string hand, GameObject go)
    {
        if(hand == left)
        {
            leftHandGo = go;
            go.transform.DOMove(leftHand.transform.position,0.25f).OnComplete(() => go.transform.position = leftHand.transform.position);
            go.transform.parent = leftHand.parent;
        }
        else
        {
            rightHandGo = go;
            go.transform.DOMove(rightHand.transform.position, 0.25f).OnComplete(() => go.transform.position = rightHand.transform.position);
            go.transform.parent = rightHand.parent;
        }
        go.GetComponent<ObjectStats>().isOnHand = true;
        go.GetComponent<Rigidbody>().useGravity = false;
        go.GetComponent<BoxCollider>().enabled = false;
    }

}
