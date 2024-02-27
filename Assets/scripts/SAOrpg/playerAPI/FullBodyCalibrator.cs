using RootMotion.FinalIK;
using Thry;
using UnityEngine;
using Valve.VR;

namespace SAOrpg.playerAPI
{
    public class FullBodyCalibrator : MonoBehaviour
	{
		public VRIK ikController;
        public bool isCalibrating;

        public bool calibratedTest;

		public Transform[] trackedLocations = new Transform[8];
        public Transform[] closestTrackers = new Transform[8];

        public Transform headOffset;
        public Transform leftHandOffset;
        public Transform rightHandOffset;

        private void Start()
        {
            assignTrackedLocations();
        }

        private void Update()
        {
            if (isCalibrating)
            {
                //when the player is calibrating
                ikController.solver.IKPositionWeight = 0;
                ikController.GetComponent<Animator>().SetBool("t-pose", true);

                for (int i = 0; i < trackedLocations.Length; i++)
                {
                    closestTrackers[i] = getClosestTracker(trackedLocations[i]);
                }
            }

            //needs input updated, not testing, nly with the bool
            if (/*(Input.GetAxis("ValveIndex_TriggerLeft") > 0.9 && Input.GetAxis("ValveIndex_TriggerRight") > 0.9) ||*/ calibratedTest)
            {
                assignTrackers();
                checkDoubles();
                isCalibrating = false;
                calibratedTest = false;

                ikController.solver.IKPositionWeight = 1;
                ikController.GetComponent<Animator>().SetBool("t-pose", false);
            }
        }

        /// <summary>
        /// returns the closest tracker to the trakced location, foot, hip, etc
        /// </summary>
        /// <param name="trackedLocation">foot, hip, etc</param>
        /// <returns>closest tracker to this location</returns>
        public Transform getClosestTracker(Transform trackedLocation)
        {
            float distance = 100f;
            Transform closest = null;

            for(int i = 0; i < transform.childCount; i++)
            {
                if ((transform.GetChild(i).position - trackedLocation.position).magnitude < distance && transform.GetChild(i).gameObject.activeInHierarchy)
                {
                    distance = (transform.GetChild(i).position - trackedLocation.position).magnitude;
                    closest = transform.GetChild(i);
                }
            }

            return closest;
        }

        /// <summary>
        /// assigns tracer and offsets to VRIK, gross ik
        /// </summary>
        public void assignTrackers()
        {
            //move trakcer children to the assigned tracked location

            closestTrackers[0].GetChild(0).position = trackedLocations[0].position;
            closestTrackers[0].GetChild(0).rotation = trackedLocations[0].rotation;
            ikController.solver.spine.pelvisTarget = closestTrackers[0].GetChild(0);

            closestTrackers[1].GetChild(0).position = trackedLocations[1].position;
            closestTrackers[1].GetChild(0).rotation = trackedLocations[1].rotation;
            ikController.solver.spine.chestGoal = closestTrackers[1].GetChild(0);

            closestTrackers[2].GetChild(0).position = trackedLocations[2].position;
            closestTrackers[2].GetChild(0).rotation = trackedLocations[2].rotation;
            ikController.solver.leftArm.bendGoal = closestTrackers[2].GetChild(0);

            closestTrackers[3].GetChild(0).position = trackedLocations[3].position;
            closestTrackers[3].GetChild(0).rotation = trackedLocations[3].rotation;
            ikController.solver.rightArm.bendGoal = closestTrackers[3].GetChild(0);

            closestTrackers[4].GetChild(0).position = trackedLocations[4].position;
            closestTrackers[4].GetChild(0).rotation = trackedLocations[4].rotation;
            ikController.solver.leftLeg.bendGoal = closestTrackers[4].GetChild(0);

            closestTrackers[5].GetChild(0).position = trackedLocations[5].position;
            closestTrackers[5].GetChild(0).rotation = trackedLocations[5].rotation;
            ikController.solver.rightLeg.bendGoal = closestTrackers[5].GetChild(0);

            closestTrackers[6].GetChild(0).position = trackedLocations[6].position;
            closestTrackers[6].GetChild(0).rotation = trackedLocations[6].rotation;
            ikController.solver.leftLeg.target = closestTrackers[6].GetChild(0);

            closestTrackers[7].GetChild(0).position = trackedLocations[7].position;
            closestTrackers[7].GetChild(0).rotation = trackedLocations[7].rotation;
            ikController.solver.rightLeg.target = closestTrackers[7].GetChild(0);

            /*
            headOffset.position = ikController.references.head.position;
            headOffset.rotation = ikController.references.head.rotation;
            ikController.solver.spine.headTarget = headOffset;

            leftHandOffset.position = ikController.references.leftHand.position;
            leftHandOffset.rotation = ikController.references.leftHand.rotation;
            ikController.solver.leftArm.target = leftHandOffset;

            rightHandOffset.position = ikController.references.rightHand.position;
            rightHandOffset.rotation = ikController.references.rightHand.rotation;
            ikController.solver.rightArm.target = rightHandOffset;
            */
            //then assign the child to the goal of the ikController
        }

        /// <summary>
        /// gets tracked locations based in VRIK
        /// </summary>
        public void assignTrackedLocations()
        {
            trackedLocations[0] = ikController.references.pelvis;
            trackedLocations[1] = ikController.references.chest;
            trackedLocations[2] = ikController.references.leftForearm;
            trackedLocations[3] = ikController.references.rightForearm;
            trackedLocations[4] = ikController.references.leftCalf;
            trackedLocations[5] = ikController.references.rightCalf;
            trackedLocations[6] = ikController.references.leftFoot;
            trackedLocations[7] = ikController.references.rightFoot;
        }

        /// <summary>
        /// checks for two tracked locations with same tracker. ex: knee and foot have same tracker so set knee to null
        /// </summary>
        public void checkDoubles()
        {
            #region chestSection

            for (int i = 0; i < 2; i++)
            {
                if (closestTrackers[i] == closestTrackers[i+1])
                {
                    closestTrackers[i+1] = null;
                }
            }

            #endregion

            #region legSection

            if (closestTrackers[4] == closestTrackers[5])
            {
                if ((trackedLocations[4].position - closestTrackers[4].position).magnitude < (trackedLocations[5].position - closestTrackers[4].position).magnitude)
                {
                    ikController.solver.leftLeg.bendGoal = null;
                }
                else
                {
                    ikController.solver.rightLeg.bendGoal = null;
                }
            }

            if (closestTrackers[6] == closestTrackers[7])
            {
                if ((trackedLocations[6].position - closestTrackers[6].position).magnitude < (trackedLocations[7].position - closestTrackers[6].position).magnitude)
                {
                    ikController.solver.rightLeg.target = null;
                }
                else
                {
                    ikController.solver.leftLeg.target = null;
                }
            }


            #endregion

        }
    }
}
