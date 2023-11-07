using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;
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
        public poseDirectionObject.directions topDownDirection;
        public poseDirectionObject.directions sideSideDirection;

        public Vector3 topDownCam = Vector3.zero;
        public Vector3 sideSideCam = Vector3.zero;
        public Vector3 topDownVelocity = Vector3.zero;
        public Vector3 sideSideVeclocity = Vector3.zero;

        #endregion

        private void OnTriggerEnter(Collider hitObject)
        {
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

        private void getDirections()
        {
            Vector3 velocity = GetComponent<VelocityEstimator>().GetVelocityEstimate();


            sideSideVeclocity.x = velocity.x;
            sideSideVeclocity.y = 1;
            sideSideVeclocity.z = velocity.y;

            topDownVelocity.x = velocity.x;
            topDownVelocity.y = velocity.z;

            sideSideVeclocity = sideSideVeclocity.normalized;
            topDownVelocity = topDownVelocity.normalized;

            sideSideCam.y = playerCamera.forward.x;
            sideSideCam.x = playerCamera.forward.y;
            sideSideCam.z = playerCamera.forward.z;



            topDownCam.x = playerCamera.forward.x;
            topDownCam.y = playerCamera.forward.z;

            //playerCamera.InverseTransformVector(sideSideCam);

            topDownVelocity *= -1;

            float topDownAngle = Vector2.SignedAngle(topDownCam, topDownVelocity);


            // use this to check top/down angle
            if (topDownAngle > 45)
            {
                topDownDirection = poseDirectionObject.directions.left;
            }
            else if (topDownAngle < -45)
            {
                topDownDirection = poseDirectionObject.directions.right;
            }
            else if (topDownAngle <= 45 && topDownAngle >= -45)
            {
                topDownDirection = poseDirectionObject.directions.pierce;
            }

            float sideSideAngle = Vector2.SignedAngle(new Vector2(sideSideCam.y, sideSideCam.z), new Vector2(sideSideVeclocity.y, sideSideVeclocity.z));


            //use this to check top/down angle
            if (sideSideAngle < -135)
            {
                sideSideDirection = poseDirectionObject.directions.down;
            }
            else if (sideSideAngle >= -135 && sideSideAngle <= -45)
            {
                sideSideDirection = poseDirectionObject.directions.pierce;
            }
            else if (sideSideAngle > -45)
            {
                sideSideDirection = poseDirectionObject.directions.up;
            }
        }

        private void setMaster()
        {
            if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.pierce)
            {
                lastHitDirection = poseDirectionObject.directions.left;
            }
            if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.up)
            {
                lastHitDirection = poseDirectionObject.directions.leftUp;
            }
            if (topDownDirection == poseDirectionObject.directions.left && sideSideDirection == poseDirectionObject.directions.down)
            {
                lastHitDirection = poseDirectionObject.directions.leftDown;
            }
            if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.pierce)
            {
                lastHitDirection = poseDirectionObject.directions.right;
            }
            if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.up)
            {
                lastHitDirection = poseDirectionObject.directions.rightUp;
            }
            if (topDownDirection == poseDirectionObject.directions.right && sideSideDirection == poseDirectionObject.directions.down)
            {
                lastHitDirection = poseDirectionObject.directions.rightDown;
            }
            if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.up)
            {
                lastHitDirection = poseDirectionObject.directions.up;
            }
            if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.down)
            {
                lastHitDirection = poseDirectionObject.directions.down;
            }
            if (topDownDirection == poseDirectionObject.directions.pierce && sideSideDirection == poseDirectionObject.directions.pierce)
            {
                lastHitDirection = poseDirectionObject.directions.pierce;
            }
        }

        private void Update()
        {
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


            getDirections();
            setMaster();

        }
    }
}


