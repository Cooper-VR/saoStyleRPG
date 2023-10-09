using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    public Transform alignmentObject;
    public Vector3 rotationOffset;
    public rigidBodyGravity rigidBodyBehavior;

    private bool dropped;

    [Header("test stuff")]
    public Transform controller;

    public enum rigidBodyGravity
    {
        useGravity,
        noGravity
    }
    public void positionItem()
    {
        transform.position = controller.position;
        transform.rotation = Quaternion.Euler(alignmentObject.rotation.eulerAngles + rotationOffset);

        gameObject.GetComponent<Rigidbody>().useGravity = true;
        gameObject.GetComponent<Rigidbody>().isKinematic = true;
    }

    public void itemDropped()
    {
        if (rigidBodyBehavior == rigidBodyGravity.useGravity)
        {
            gameObject.GetComponent<Rigidbody>().useGravity = true;
            gameObject.GetComponent<Rigidbody>().isKinematic = false;
        }
        else
        {
            gameObject.GetComponent<Rigidbody>().isKinematic = true;
        }
    }
}



