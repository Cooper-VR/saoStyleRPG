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
        rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexProximal));
        rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexIntermediate));
        rotateFinger(0, playerRig.GetBoneTransform(HumanBodyBones.LeftIndexProximal));

        rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleProximal));
        rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleIntermediate));
        rotateFinger(1, playerRig.GetBoneTransform(HumanBodyBones.LeftMiddleProximal));

        rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingProximal));
        rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingIntermediate));
        rotateFinger(2, playerRig.GetBoneTransform(HumanBodyBones.LeftRingProximal));

        rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleProximal));
        rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleIntermediate));
        rotateFinger(3, playerRig.GetBoneTransform(HumanBodyBones.LeftLittleProximal));

        rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbProximal));
        rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbIntermediate));
        rotateThumb(4, playerRig.GetBoneTransform(HumanBodyBones.LeftThumbProximal));
    }

    private void rotateFinger(int index, Transform fingerJoint)
    {
        float angle = -80f;

        float amount = fingerInput.leftFinger[index];

        Vector3 rotation = new Vector3(0, 0, 0);

        rotation.x = amount * angle;

        fingerJoint.localEulerAngles = rotation;
    }

    private void rotateThumb(int index, Transform fingerJoint)
    {
        float angle = -40f;

        float amount = fingerInput.leftFinger[index];

        Vector3 rotation = new Vector3(0, 0, 0);

        rotation.z = amount * angle;

        fingerJoint.localEulerAngles = rotation;
    }
}
