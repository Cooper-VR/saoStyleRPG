using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using SAOrpg.playerAPI;

namespace SAOrpg.climbing
{
    public class climbingMaster : MonoBehaviour
    {
        private GameObject leftHand;
        private GameObject rightHand;

        private climbingHands leftHandParems;
        private climbingHands rightHandParems;

        private bool leftGrabbed;
        private bool rightGrabbed;

        private IndexInput input;

        private void Start()
        {
            input = GetComponent<IndexInput>();

            leftHand = transform.GetChild(0).gameObject;
            rightHand = transform.GetChild(1).gameObject;

            leftHandParems = leftHand.GetComponent<climbingHands>();
            rightHandParems = rightHand.GetComponent<climbingHands>();
        }

        // Update is called once per frame
        void Update()
        {
            //check if one of the hands is currently touching
            if (leftHandParems.currentlyTouching && input.leftFinger[0] > 0.9f)
            {
                leftGrabbed = true;
            }
            else if (leftHandParems.currentlyTouching && input.leftFinger[0] > 0.9f && rightGrabbed)
            {
                leftGrabbed = true;
                rightGrabbed = false;
            }
            else
            {
                leftGrabbed = false;
            }

            if (rightHandParems.currentlyTouching && input.rightFinger[0] > 0.9f)
            {
                rightGrabbed = true;
            }
            else if (rightHandParems.currentlyTouching && input.rightFinger[0] > 0.9f && leftGrabbed)
            {
                rightGrabbed = true;
                leftGrabbed = false;
            }
            else
            {
                rightGrabbed = false;
            }

            if (leftGrabbed)
            {
                movePlayer(leftHand);
            }
            else if (rightGrabbed)
            {
                movePlayer(rightHand);
            }
            //check if one of the triggers are being pressed

            //if both are for the same hand, move body in relation to that hand

            //if the other also does that after then move in realtion to that hand

            if (!(leftGrabbed || rightGrabbed))
            {
                dropPlayer();
            }
        }

        private void movePlayer(GameObject anchorObject)
        {
            Rigidbody rb = anchorObject.GetComponent<Rigidbody>();

            Vector3 handVelocity = rb.velocity;

            GetComponent<playerMovement>().velocity = handVelocity * -1;
        }
        private void dropPlayer()
        {
            GameObject head = GetComponent<playerMovement>().camera.gameObject;

            RaycastHit hit;

            if (Physics.Raycast(head.transform.position, Vector3.down, out hit, float.MaxValue))
            {
                transform.position = hit.point;
            }
        }
    }
}

