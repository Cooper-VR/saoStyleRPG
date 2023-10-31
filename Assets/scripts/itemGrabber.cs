using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAOrpg.playerAPI;

namespace SAOrpg.items
{
    public class itemGrabber : MonoBehaviour
    {
        #region variables
        GameObject[] pickables = null;
        GameObject closestObject;

        public Transform leftHand;
        public Transform rightHand;

        public GameObject leftClosest;
        public GameObject rightClosest;

        public float threshold = 0.3f;

        private IndexInput input;

        private bool leftDropped;
        private bool rightDropped;
        #endregion

        #region start/update

        private void Start()
        {
            //get index input
            input = GetComponent<IndexInput>();
        }

        private void Update()
        {
            //check if they are gripping on left and right
            if (input.isGrippingLeft)
            {

                leftDropped = false;
                pickables = GameObject.FindGameObjectsWithTag("Pickupable");

                //get closest pickup
                leftClosest = findClosest(leftHand);

                //check if its close enough
                if (Mathf.Abs((leftClosest.transform.position - leftHand.position).magnitude) < threshold)
                {
                    //assign the values for the pickup script
                    PickupableObject pickup = leftClosest.GetComponent<PickupableObject>();
                    pickup.controller = leftHand;
                    pickup.alignmentObject = leftHand;
                    pickup.positionItem();
                }
            }
            else
            {
                //alternate for when its dropped
                if (!leftDropped)
                {
                    pickables = GameObject.FindGameObjectsWithTag("Pickupable");

                    rightClosest = findClosest(rightHand);

                    PickupableObject pickup = rightClosest.GetComponent<PickupableObject>();
                    pickup.controller = null;
                    pickup.alignmentObject = null;
                    pickup.itemDropped();
                    leftDropped = true;
                }
            }

            if (input.isGrippingRight)
            {
                //same for other hand
                rightDropped = false;
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
                //alternate for when its dropped
                if (!rightDropped)
                {
                    pickables = GameObject.FindGameObjectsWithTag("Pickupable");

                    rightClosest = findClosest(rightHand);

                    PickupableObject pickup = rightClosest.GetComponent<PickupableObject>();
                    pickup.controller = null;
                    pickup.alignmentObject = null;
                    pickup.itemDropped();
                    rightDropped = true;
                }
            }
        }
        #endregion

        #region helper functions

        /// <summary>
        /// finds the closest object to the argument
        /// </summary>
        /// <param name="controller">the controller that is grabbing</param>
        /// <returns>the closes gameobject</returns>
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
        #endregion
    }
}

