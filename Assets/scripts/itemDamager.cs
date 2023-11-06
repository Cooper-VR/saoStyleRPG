using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;
using UnityEngine.UIElements;
using Valve.VR.InteractionSystem;

namespace SAOrpg.items
{
    public class itemDamager : MonoBehaviour
    {
        /// <summary>
        /// enum for the sharp vector direction
        /// </summary>
        public enum SharpDirection
        {
            forward,
            backward,
            right,
            left,
            up,
            down,
            none
        }

        #region variables
        public SharpDirection sharpDirection;

        public int strengthRequirement;
        public int duribility;
        public int maxDamage;
        public Transform playerCamera;

        public poseDirectionObject.directions lastHitDirection;

        public Vector3 topDownCam = Vector3.zero;
        public Vector3 sideSideCam = Vector3.zero;
        public Vector3 topDownVelocity = Vector3.zero;
        public Vector3 sideSideVeclocity = Vector3.zero;

        #endregion

        private void OnTriggerEnter(Collider hitObject)
        {
            /*
            Vector3 Velocity = GetComponent<VelocityEstimator>().GetVelocityEstimate();

            sideSideVeclocity.x = GetComponent<VelocityEstimator>().GetVelocityEstimate().x;
            sideSideVeclocity.y = GetComponent<VelocityEstimator>().GetVelocityEstimate().y;

            topDownVelocity.x = GetComponent<VelocityEstimator>().GetVelocityEstimate().x;
            topDownVelocity.y = GetComponent<VelocityEstimator>().GetVelocityEstimate().z;

            sideSideVeclocity = sideSideVeclocity.normalized;
            topDownVelocity = topDownVelocity.normalized;

            sideSideCam.x = playerCamera.forward.x;
            sideSideCam.y = playerCamera.forward.y;

            topDownCam.x = playerCamera.forward.x;
            topDownCam.y = playerCamera.forward.z;
            */

            

            //get direction

            //get the angle of the forward of the camera vs the velocity of the item

            //check of closer to pi/2, 0, or 3pi/2 on the top/down view
            //pi/2 mean left swing(for me), 0 pierce, 3pi/2 right swing (for me). mirror for right handed people

            //check angle for the side view
            //(this is for right and left handed)
            //pi/2 down to up, 3pi/2 up to down

            //once i get those, get if its left, right or peice
            //get if its up, down, or peirce

            //using that check if its one of the eight directions


        }

        private void Update()
        {
            Vector3 velocity = GetComponent<VelocityEstimator>().GetVelocityEstimate();

            sideSideVeclocity.x = velocity.x;
            sideSideVeclocity.y = velocity.y;
            sideSideVeclocity.z = velocity.z;

            topDownVelocity.x = velocity.x;
            topDownVelocity.y = velocity.z;

            sideSideVeclocity = sideSideVeclocity.normalized;
            topDownVelocity = topDownVelocity.normalized;

            sideSideCam.x = playerCamera.forward.x;
            sideSideCam.y = playerCamera.forward.y;
            sideSideCam.z = playerCamera.forward.z;

            topDownCam.x = playerCamera.forward.x;
            topDownCam.y = playerCamera.forward.z;

            playerCamera.InverseTransformVector(sideSideCam);

            topDownVelocity *= -1;

            float topDownAngle = Vector2.SignedAngle(topDownCam, topDownVelocity);
            

            /* use this to check top/down angle
            if (topDownAngle > 45)
            {
                Debug.Log("closer to 90");
            }else if (topDownAngle < -45)
            {
                Debug.Log("closer to -90");
            }
            else if (topDownAngle <= 45 && topDownAngle >= -45)
            {
                Debug.Log("closer to 0");
            }*/

            float sideSideAngle = Vector2.SignedAngle(sideSideCam, sideSideVeclocity);
            Debug.Log(sideSideAngle);

            if (sideSideAngle > 45)
            {
                Debug.Log("closer to 90");
            }
            else if (sideSideAngle < -45)
            {
                Debug.Log("closer to -90");
            }
            else if (sideSideAngle <= 45 && sideSideAngle >= -45)
            {
                Debug.Log("closer to 0");
            }

            
        }
    }
}


