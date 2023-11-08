using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.sheath
{
    public class sheathHandler : MonoBehaviour
    {
        public Transform Hips;
        public Transform Back;

        private Animator animator;

        private void Start()
        {
            animator = transform.parent.gameObject.GetComponent<Animator>();
        }

        private void FixedUpdate()
        {
            Hips.transform.position = animator.GetBoneTransform(HumanBodyBones.Hips).transform.position;
            Back.transform.position = animator.GetBoneTransform (HumanBodyBones.Chest).transform.position;

            Hips.transform.rotation = animator.GetBoneTransform(HumanBodyBones.Hips).transform.rotation;
            Back.transform.rotation = animator.GetBoneTransform(HumanBodyBones.Chest).transform.rotation;
        }
    }
}
