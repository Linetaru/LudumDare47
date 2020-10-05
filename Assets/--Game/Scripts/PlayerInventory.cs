﻿using System.Collections;
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

    public int takeObjectMaxDistanceRayCast;
    public int dropObjectMaxDistanceRayCast;

    const string left = "left";
    const string right = "right";

    public LineRenderer rightLineRenderer;
    public LineRenderer leftLineRenderer;

    private bool isSetPositionLineRenderLeft;
    private bool isSetPositionLineRenderRight;

    // Start is called before the first frame update
    void Start()
    {
        leftLineRenderer.startWidth = 0.2f;
        leftLineRenderer.endWidth = 0.2f;
        rightLineRenderer.startWidth = 0.2f;
        rightLineRenderer.endWidth = 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        leftLineRenderer.SetPosition(0, leftHand.transform.position);
        rightLineRenderer.SetPosition(0, rightHand.transform.position);

        if (!isSetPositionLineRenderLeft)
            leftLineRenderer.SetPosition(1, leftHand.transform.position);
        if (!isSetPositionLineRenderRight)
            rightLineRenderer.SetPosition(1, rightHand.transform.position);

        if (Input.GetMouseButtonDown(0))
        {
            if(leftHandGo != null)
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, dropObjectMaxDistanceRayCast, layerMaskNoPlayer))
                {
                    DropObjectInHand(left, hit.point);
                }
            }
            else
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, takeObjectMaxDistanceRayCast, layerMaskObject))
                {
                    if(hit.collider.gameObject.layer == 8)
                        AddObjectInInventory(left, hit.collider.gameObject);
                }
            }
        }
        if (Input.GetMouseButtonDown(1))
        {
            if (rightHandGo != null)
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, dropObjectMaxDistanceRayCast, layerMaskNoPlayer))
                {
                    DropObjectInHand(right, hit.point);
                    
                }
            }
            else
            {
                if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, takeObjectMaxDistanceRayCast, layerMaskObject))
                {
                    if (hit.collider.gameObject.layer == 8)
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
            isSetPositionLineRenderLeft = true;
            leftHandGo.transform.parent = null;
            inventoryObjects.Remove(leftHandGo);
            leftHandGo.transform.DOMove(point + new Vector3(0, 0.5f, 0), 0.25f)
                .OnUpdate(() => leftLineRenderer.SetPosition(1, leftHandGo.transform.position))
                .OnComplete(() => {
                    isSetPositionLineRenderLeft = false;
                    leftHandGo = null;
                });
            leftHandGo.GetComponent<Rigidbody>().isKinematic = false;
            leftHandGo.GetComponent<BoxCollider>().enabled = true;
            if (leftHandGo.GetComponent<ObjectStats>() != null)
                leftHandGo.GetComponent<ObjectStats>().isOnHand = false;
        }
        else
        {
            isSetPositionLineRenderRight = true;
            rightHandGo.transform.parent = null;
            inventoryObjects.Remove(rightHandGo);
            rightHandGo.transform.DOMove(point + new Vector3(0, 0.5f, 0), 0.25f)
                .OnUpdate(() => rightLineRenderer.SetPosition(1, rightHandGo.transform.position))
                .OnComplete(() => {
                    isSetPositionLineRenderRight = false;
                    rightHandGo = null;
                });
            rightHandGo.GetComponent<Rigidbody>().isKinematic = false;
            rightHandGo.GetComponent<BoxCollider>().enabled = true;
            if (rightHandGo.GetComponent<ObjectStats>() != null)
                rightHandGo.GetComponent<ObjectStats>().isOnHand = false;
        }
    }

    public void SetObjectInHand(string hand, GameObject go)
    {
        if (hand == left)
        {
            isSetPositionLineRenderLeft = true;
            leftHandGo = go;
            go.transform.DOMove(leftHand.transform.position, 0.2f)
                .OnUpdate(() => leftLineRenderer.SetPosition(1, go.transform.position))
                .OnComplete(() => {
                    go.transform.position = leftHand.transform.position;
                    go.transform.rotation = Quaternion.Euler(-90, go.transform.rotation.y, go.transform.rotation.z);
                    go.GetComponent<BoxCollider>().enabled = false;
                    isSetPositionLineRenderLeft = false;
                });
            go.transform.parent = leftHand.parent;
        }
        else
        {
            isSetPositionLineRenderRight = true;
            rightHandGo = go;
            go.transform.DOMove(rightHand.transform.position, 0.2f)
                .OnUpdate(() => rightLineRenderer.SetPosition(1, go.transform.position))
                .OnComplete(() => {
                    go.transform.position = rightHand.transform.position;
                    go.transform.rotation = Quaternion.Euler(-90, go.transform.rotation.y, go.transform.rotation.z);
                    go.GetComponent<BoxCollider>().enabled = false;
                    isSetPositionLineRenderRight = false;
                });
            go.transform.parent = rightHand.parent;
        }
        if(go.GetComponent<ObjectStats>() != null)
            go.GetComponent<ObjectStats>().isOnHand = true;
        go.GetComponent<Rigidbody>().isKinematic = true;
    }

}
