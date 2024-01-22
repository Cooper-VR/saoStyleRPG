using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.Fighting
{
    public class DamageColliderHandler : MonoBehaviour
    {
        #region
        public Animator animator;
        public CapsuleCollider torso;
        public CapsuleCollider leftLeg;
        public CapsuleCollider rightLeg;
        public CapsuleCollider leftArm;
        public CapsuleCollider rightArm;

        [HideInInspector]
        public collisionChecker torsoCheck;
        [HideInInspector]
        public collisionChecker leftLegCheck;
        [HideInInspector]
        public collisionChecker rightLegCheck;
        [HideInInspector]
        public collisionChecker leftArmCheck;
        [HideInInspector]
        public collisionChecker rightArmCheck;
        #endregion

        #region
        private void Awake()
        {
            //get the collider checkers
            torsoCheck = torso.GetComponent<collisionChecker>();
            leftLegCheck = leftLeg.GetComponent<collisionChecker>();
            rightLegCheck = rightLeg.GetComponent<collisionChecker>();
            leftArmCheck = leftArm.GetComponent<collisionChecker>();
            rightArmCheck = rightArm.GetComponent<collisionChecker>();
        }

        void FixedUpdate()
        {
            //get the midpoint, distance, and set the forward and apply radius scale
            torso.transform.position = midpoint(animator.GetBoneTransform(HumanBodyBones.Hips), animator.GetBoneTransform(HumanBodyBones.Head));
            torso.height = getBoneDistance(animator.GetBoneTransform(HumanBodyBones.Hips), animator.GetBoneTransform(HumanBodyBones.Head));
            torso.transform.forward = direction(animator.GetBoneTransform(HumanBodyBones.Hips), animator.GetBoneTransform(HumanBodyBones.Head));
            torso.radius = scaleRadius(torso, 4);

            leftLeg.transform.position = midpoint(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), animator.GetBoneTransform(HumanBodyBones.LeftFoot));
            leftLeg.height = getBoneDistance(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), animator.GetBoneTransform(HumanBodyBones.LeftFoot));
            leftLeg.transform.forward = direction(animator.GetBoneTransform(HumanBodyBones.LeftUpperLeg), animator.GetBoneTransform(HumanBodyBones.LeftFoot));
            leftLeg.radius = scaleRadius(leftLeg, 8);

            rightLeg.transform.position = midpoint(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg), animator.GetBoneTransform(HumanBodyBones.RightFoot));
            rightLeg.height = getBoneDistance(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg), animator.GetBoneTransform(HumanBodyBones.RightFoot));
            rightLeg.transform.forward = direction(animator.GetBoneTransform(HumanBodyBones.RightUpperLeg), animator.GetBoneTransform(HumanBodyBones.RightFoot));
            rightLeg.radius = scaleRadius(rightLeg, 8);

            leftArm.transform.position = midpoint(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm), animator.GetBoneTransform(HumanBodyBones.LeftHand));
            leftArm.height = getBoneDistance(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm), animator.GetBoneTransform(HumanBodyBones.LeftHand));
            leftArm.transform.forward = direction(animator.GetBoneTransform(HumanBodyBones.LeftUpperArm), animator.GetBoneTransform(HumanBodyBones.LeftHand));
            leftArm.radius = scaleRadius(leftArm, 9);

            rightArm.transform.position = midpoint(animator.GetBoneTransform(HumanBodyBones.RightUpperArm), animator.GetBoneTransform(HumanBodyBones.RightHand));
            rightArm.height = getBoneDistance(animator.GetBoneTransform(HumanBodyBones.RightUpperArm), animator.GetBoneTransform(HumanBodyBones.RightHand));
            rightArm.transform.forward = direction(animator.GetBoneTransform(HumanBodyBones.RightUpperArm), animator.GetBoneTransform(HumanBodyBones.RightHand));
            rightArm.radius = scaleRadius(rightArm, 9);
        }
        #endregion

        #region helper functions
        /// <summary>
        /// returns a scale value for the radius of colliders
        /// </summary>
        /// <param name="col">the collider to be scaled</param>
        /// <param name="amount">the scale factor</param>
        /// <returns></returns>
        private float scaleRadius(CapsuleCollider col , float amount)
        {
            return col.height / amount;
        }

        /// <summary>
        /// subtracts two transforms and normalizes the vector
        /// </summary>
        /// <param name="firstBone">the origin of the vector</param>
        /// <param name="secondBone">the direction the vector points</param>
        /// <returns>a vector3 of the direction in 3D space</returns>
        private Vector3 direction(Transform firstBone, Transform secondBone)
        {
            return (secondBone.position - firstBone.position).normalized;
        }

        /// <summary>
        /// preforms pythadgrian theorem
        /// </summary>
        /// <param name="firstBone">the first point</param>
        /// <param name="secondBone">the secon point</param>
        /// <returns>the float distance of between the two points</returns>
        private float getBoneDistance(Transform firstBone, Transform secondBone)
        {
            return Mathf.Abs((firstBone.position - secondBone.position).magnitude);
        }

        /// <summary>
        /// get the midpoint of two transforms in 3D space
        /// </summary>
        /// <param name="firstBone"> the first transform</param>
        /// <param name="secondBone">the second transform</param>
        /// <returns>the the midpoint of the two arguments in 3D space</returns>
        private Vector3 midpoint(Transform firstBone, Transform secondBone)
        {
            return (firstBone.position + secondBone.position) / 2f;
        }
        #endregion
    }
}
