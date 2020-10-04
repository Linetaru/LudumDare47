using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ObjectStats : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector] public bool isOnHand;
    public bool isObjectCanBeDuplicate;

    public int numberOfCubeSpawnable;

    private bool alreadyUseToBeDuplicate;

    private void Start()
    {
        startPosition = this.transform.position;
        isOnHand = false;
        alreadyUseToBeDuplicate = false;
    }

    public void ResetObject()
    {
        if(alreadyUseToBeDuplicate && !isOnHand)
        {
            Destroy(this.gameObject);
        }

        if (!isOnHand)
            this.transform.DOMove(startPosition,0.001f);

        if (isObjectCanBeDuplicate && isOnHand)
        {
            if (GameObject.FindGameObjectsWithTag(this.gameObject.tag).Length <= numberOfCubeSpawnable)
            {
                GameObject gameObject = Instantiate(this.gameObject);
                gameObject.transform.position = startPosition;
                gameObject.GetComponent<Rigidbody>().useGravity = true;
                gameObject.GetComponent<BoxCollider>().enabled = true;
                gameObject.GetComponent<ObjectStats>().isOnHand = false;
                gameObject.name = this.gameObject.name;
                alreadyUseToBeDuplicate = true;
            }
        }
    }
}
