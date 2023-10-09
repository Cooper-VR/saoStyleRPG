using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupableObject : MonoBehaviour
{
    public Transform alignmentObject;
    public Vector3 rotationOffset;
    public rigidBodyGravity rigidBodyBehavior;

    [Header("test stuff")]
    public Transform leftController;

    private void Update()
    {
        transform.position = leftController.position;

        transform.rotation = Quaternion.Euler(alignmentObject.rotation.eulerAngles + rotationOffset);
    }

    public enum rigidBodyGravity
    {
        useGravity,
        noGravity
    }
}



