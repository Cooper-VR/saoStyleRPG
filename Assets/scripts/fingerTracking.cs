using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class fingerTracking : MonoBehaviour
{
    public IndexInput fingerInput;
    private Animator playerRig;

    private void Start()
    {
        playerRig = GetComponent<Animator>();
    }

    private void FixedUpdate()
    {
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

    private void rotateFinger(int index, Transform fingerJoint, string type)
    {
        float angle = -80f;
        float amount;

        if (type == "left")
        {
            amount = fingerInput.leftFinger[index];
        }
        else
        {
            amount = fingerInput.rightFinger[index];
        }
        

        Vector3 rotation = new Vector3(0, 0, 0);

        rotation.x = amount * angle;

        fingerJoint.localEulerAngles = rotation;
    }

    private void rotateThumb(int index, Transform fingerJoint, string type)
    {
        float angle = -40f;
        float amount;

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

        Vector3 rotation = new Vector3(0, 0, 0);

        rotation.z = amount * angle;

        fingerJoint.localEulerAngles = rotation;
    }
}
