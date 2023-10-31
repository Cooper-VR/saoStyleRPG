using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

namespace SAOrpg.playerAPI
{
    public class fingerTracking : MonoBehaviour
    {
        #region variables
        public IndexInput fingerInput;
        private Animator playerRig;
        #endregion

        private void Start()
        {
            //get the animator
            playerRig = GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            //rotation all finger joints
            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexProximal), "left");
            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate), "left");
            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexProximal), "left");

            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), "left");
            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate), "left");
            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleProximal), "left");

            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingProximal), "left");
            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingIntermediate), "left");
            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingProximal), "left");

            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleProximal), "left");
            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate), "left");
            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleProximal), "left");

            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbProximal), "left");
            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate), "left");
            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbProximal), "left");

            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.RightIndexProximal), "right");
            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.RightIndexIntermediate), "right");
            rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.RightIndexProximal), "right");

            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.RightMiddleProximal), "right");
            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.RightMiddleIntermediate), "right");
            rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.RightMiddleProximal), "right");

            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.RightRingProximal), "right");
            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.RightRingIntermediate), "right");
            rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.RightRingProximal), "right");

            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.RightLittleProximal), "right");
            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.RightLittleIntermediate), "right");
            rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.RightLittleProximal), "right");

            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.RightThumbProximal), "right");
            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.RightThumbIntermediate), "right");
            rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.RightThumbProximal), "right");
        }

        #region helperfunctions

        /// <summary>
        /// will rotate the disired finger based inindex input
        /// </summary>
        /// <param name="index">the index of the finger to use</param>
        /// <param name="fingerJoint">the transform of the finger bone</param>
        /// <param name="type">left or right</param>
        private void rotateFinger(int index, Transform fingerJoint, string type)
        {
            //base angle
            float angle = -80f;
            float amount;
            
            //check which hand it is
            if (type == "left")
            {
                amount = fingerInput.leftFinger[index];
            }
            else
            {
                amount = fingerInput.rightFinger[index];
            }

            //just do a percent amount of the base angle
            Vector3 rotation = new Vector3(0, 0, 0);
            rotation.x = amount * angle;

            //rotate
            fingerJoint.localEulerAngles = rotation;
        }

        /// <summary>
        /// used to rotate the thumb 
        /// </summary>
        /// <param name="index">the index that the thumb data is stored in</param>
        /// <param name="fingerJoint">the joint to rotate</param>
        /// <param name="type">left or right</param>
        private void rotateThumb(int index, Transform fingerJoint, string type)
        {
            //bas
            float angle;
            float amount;

            //check if its left or right to get angle rotation
            if (type == "left")
            {
                amount = fingerInput.leftFinger[index];
                angle = -40f;
            }
            else
            {
                amount = fingerInput.rightFinger[index];
                angle = 40f;
            }

            //rotate from that
            Vector3 rotation = new Vector3(0, 0, 0);
            rotation.z = amount * angle;
            fingerJoint.localEulerAngles = rotation;
        }

        #endregion
    }
}

