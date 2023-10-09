using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemGrabber : MonoBehaviour
{
    GameObject[] pickables = null;
    GameObject closestObject;

    public Transform leftHand;
    public Transform rightHand;

    public GameObject leftClosest;
    public GameObject rightClosest;

    public float threshold = 0.3f;

    private IndexInput input;

    private void Start()
    {
        input = GetComponent<IndexInput>();
    }

    private void Update()
    {
        if (input.isGrippingLeft)
        {
            pickables = GameObject.FindGameObjectsWithTag("Pickupable");

            leftClosest = findClosest(leftHand);

            if (Mathf.Abs((leftClosest.transform.position - leftHand.position).magnitude) < threshold)
            {
                PickupableObject pickup = leftClosest.GetComponent<PickupableObject>();
                pickup.controller = leftHand;
                pickup.alignmentObject = leftHand;
                pickup.positionItem();
            }
        }
        else
        {
            pickables = GameObject.FindGameObjectsWithTag("Pickupable");

            rightClosest = findClosest(rightHand);

            PickupableObject pickup = rightClosest.GetComponent<PickupableObject>();
            pickup.controller = null;
            pickup.alignmentObject = null;
            pickup.itemDropped();
        }

        if (input.isGrippingRight)
        {
            pickables = GameObject.FindGameObjectsWithTag("Pickupable");

            rightClosest = findClosest(rightHand);

            if (Mathf.Abs((rightClosest.transform.position - rightHand.position).magnitude) < threshold)
            {
                PickupableObject pickup = rightClosest.GetComponent<PickupableObject>();
                pickup.controller = rightHand;
                pickup.alignmentObject = rightHand;
                pickup.positionItem();
            }
        }
        else
        {
            pickables = GameObject.FindGameObjectsWithTag("Pickupable");

            rightClosest = findClosest(rightHand);

            PickupableObject pickup = rightClosest.GetComponent<PickupableObject>();
            pickup.controller = null;
            pickup.alignmentObject = null;
            pickup.itemDropped();
        }
        
    }

    private GameObject findClosest(Transform controller)
    {
        float closestDistance = float.MaxValue;

        foreach (GameObject obj in pickables)
        {
            
            float distance = Vector3.Distance(obj.transform.position, controller.position);

            if (distance < closestDistance)
            {
                closestDistance = distance;
                closestObject = obj;
            }
        }

        if (closestObject != null)
        {
            // You've found the closest GameObject
            Debug.Log("Closest Object: " + closestObject.name);

            return closestObject;
        }
        else
        {
            return null;
            // No objects in the array
            Debug.Log("No objects to check.");
        }
    }
}
