using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.Movement
{
    public class climbingMaster : MonoBehaviour
    {
        #region variables
        //hands
        private GameObject leftHand;
        private GameObject rightHand;

        //script to get collision data
        private collisionChecker leftHandParems;
        private collisionChecker rightHandParems;

        //check if the player is grabbing
        private bool leftGrabbed;
        private bool rightGrabbed;

        //input modual
        private IndexInput input;
        #endregion

        #region start/update
        private void Start()
        {
            //get component and other objects
            input = GetComponent<IndexInput>();

            leftHand = transform.GetChild(0).gameObject;
            rightHand = transform.GetChild(1).gameObject;

            leftHandParems = leftHand.GetComponent<collisionChecker>();
            rightHandParems = rightHand.GetComponent<collisionChecker>();
        }

        // Update is called once per frame
        void Update()
        {
            //grabbing logic

            //change variables if they are grabbing
            if (leftHandParems.currentlyTouching && input.leftFinger[0] > 0.9f)
            {
                leftGrabbed = true;
            }
            //check if they are already grabbing something
            else if (leftHandParems.currentlyTouching && input.leftFinger[0] > 0.9f && rightGrabbed)
            {
                leftGrabbed = true;
                rightGrabbed = false;
            }
            else
            {
                leftGrabbed = false;
            }

            //other hand logic

            //change variables if they are grabing
            if (rightHandParems.currentlyTouching && input.rightFinger[0] > 0.9f)
            {
                rightGrabbed = true;
            }
            //check if they are already grabbing for the other hand
            else if (rightHandParems.currentlyTouching && input.rightFinger[0] > 0.9f && leftGrabbed)
            {
                rightGrabbed = true;
                leftGrabbed = false;
            }
            else
            {
                rightGrabbed = false;
            }

            //move the player based in which hand is grabbing
            if (leftGrabbed)
            {
                movePlayer(leftHand);
            }
            else if (rightGrabbed)
            {
                movePlayer(rightHand);
            }

            //run drop method if they stop grabbing
            if (!(leftGrabbed || rightGrabbed))
            {
                dropPlayer();
            }
        }
        #endregion

        #region helper functions

        /// <summary>
        /// moves player based on the velocity of the anchor object
        /// </summary>
        /// <param name="anchorObject">The hand currentlt grabbing the wall/surface</param>
        private void movePlayer(GameObject anchorObject)
        {
            //get the rigidbody's velocity and applt it to the player
            Rigidbody rb = anchorObject.GetComponent<Rigidbody>();
            Vector3 handVelocity = rb.velocity;

            GetComponent<playerMovement>().velocity = handVelocity * -1;
        }

        /// <summary>
        /// will "drop" the player using a raycast from their head to make sure they are on the ground
        /// </summary>
        private void dropPlayer()
        {
            //get the VR camera
            GameObject head = GetComponent<playerMovement>().camera.gameObject;

            //set the player position to the hit point of the raycast
            RaycastHit hit;
            if (Physics.Raycast(head.transform.position, Vector3.down, out hit, float.MaxValue))
            {
                transform.position = hit.point;
            }
        }
        #endregion
    }
}

