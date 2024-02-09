using RootMotion.FinalIK;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI
{
	public class FullBodyCalibrator : MonoBehaviour
	{
		//key: list are- left to right
		public VRIK ikController;

        private void Update()
        {
			
		}
    }

	public class IKlocation
	{
		private Transform[] trackers;
		private Transform trackedLocation;
		public Transform closestTracker;

		private float distance = 1000f;

		public IKlocation(Transform location)
		{
			trackedLocation = location;
		}

		public void getClosest()
		{
			for (int i = 0; i < trackers.Length; i++)
			{
				if ((trackers[i].position - trackedLocation.position).magnitude < distance)
				{
					closestTracker = trackers[i];
					distance = (trackers[i].position - trackedLocation.position).magnitude;
				}
			}
		}
	}
}
