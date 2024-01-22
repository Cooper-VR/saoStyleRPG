using UnityEngine;

namespace SAOrpg.playerAPI
{
    public class heightFixer : MonoBehaviour
    {
        private Animator bokoAnimator;
        private Transform rightFoot;
        private Transform leftFoot;
        public LayerMask groundMask;
        public float yOffset;

        [Range(0, 1)]
        public float weight;

        public int randomIdle;

        void Start()
        {
            bokoAnimator = transform.GetChild(0).GetChild(0).gameObject.GetComponent<Animator>();
            rightFoot = bokoAnimator.GetBoneTransform(HumanBodyBones.RightFoot);
            leftFoot = bokoAnimator.GetBoneTransform(HumanBodyBones.LeftFoot);
        }

        // Update is called once per frame
        void Update()
        {
            float leftFootDistance = getDistance(leftFoot);
            float rightFootDistance = getDistance(rightFoot);

            Vector3 childPosition = transform.GetChild(0).position;

            //if (currentAnimationName.Contains("Jump"))
            //{
            //    changeWeight(true);
            //}
            //else
            //{
            //    changeWeight(false);
            //}

            bokoAnimator.SetInteger("idleType", randomIdle);
            randomIdle = Random.Range(0, 8);
            //if (currentAnimationName == "idleEnd")
            //{
            //    bokoAnimator.SetInteger("idleType", randomIdle);
            //    randomIdle = Random.Range(0, 8);
            //}

            if (leftFootDistance < rightFootDistance)
            {
                childPosition.y -= leftFootDistance - (yOffset * weight);
                transform.GetChild(0).position = childPosition;
            }
            else if (leftFootDistance > rightFootDistance)
            {
                childPosition.y -= rightFootDistance - (yOffset * weight);
                transform.GetChild(0).position = childPosition;
            }
        }
        private float getDistance(Transform bone)
        {
            RaycastHit hit;

            Vector3 hitPosition = new Vector3();

            bool didHit = Physics.Raycast(bone.position, Vector3.down, out hit, groundMask);

            if (didHit)
            {
                hitPosition = hit.point;
                return bone.position.y - hitPosition.y;
            }
            else
            {
                didHit = Physics.Raycast(bone.position, Vector3.up, out hit, groundMask);

                hitPosition = hit.point;
                return bone.position.y - hitPosition.y;
            }
        }

        private void changeWeight(bool up)
        {
            if (up && weight > 0)
            {
                weight -= 1 * Time.deltaTime;
            }
            else if (!up && weight < 1)
            {
                weight += 1 * Time.deltaTime;
            }
        }
    }
}
