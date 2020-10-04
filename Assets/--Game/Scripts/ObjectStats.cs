using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectStats : MonoBehaviour
{
    private Vector3 startPosition;

    [HideInInspector] public bool isOnHand;
    public bool isObjectCanBeDuplicate;

    public int numberOfCubeSpawnable;

    private void Start()
    {
        startPosition = this.transform.position;
        isOnHand = false;
    }

    public void ResetObject()
    {

        if (!isOnHand)
            this.transform.position = startPosition;

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
            }
        }
    }
}
