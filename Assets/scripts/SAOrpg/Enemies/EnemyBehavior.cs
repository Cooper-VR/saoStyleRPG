using UnityEngine;
using UnityEngine.AI;

namespace SAOrpg.Enemies
{
    public class EnemyBehavior : MonoBehaviour
	{
		[Header ("state controls")]
		public bool inView;
		public bool closeEnough;
		public bool toClose;
        public bool healthIsLow;

        public RangeType rangeType;

		public int health;
		public int maxHealth;
		public Transform head;
		public GameObject player;
		public float attackRange;

        private NavMeshAgent agent;

		private float roamingRadius = 7f;
		private float scaredDistance = 15f;


		[Header("roaming")]
		Vector3 startPosition;

        public enum RangeType{
			close,
			far, 
			both
		}

        private void Start()
        {
            agent = GetComponent<NavMeshAgent>();
			startPosition = transform.position;
			roam();
            //randomPosition = new Vector3((Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4, (Random.value - 0.5f) * 4) + startPosition;

        }

        private void Update()
		{
			roam(); // Destination reached, trigger roaming again

            updateStates();
		}

        void FleePlayer()
        {
            if (player != null)
            {
                Vector3 directionToPlayer = transform.position - player.transform.position;
                Vector3 fleePosition = transform.position + directionToPlayer.normalized * scaredDistance;

                NavMeshHit hit;
                NavMesh.SamplePosition(fleePosition, out hit, roamingRadius, 1);
                Vector3 finalPosition = hit.position;

                agent.SetDestination(finalPosition);
            }
        }

        void ChasePlayer()
        {
            if (player != null)
            {
                agent.SetDestination(player.transform.position);
            }
        }


        private void roam()
		{
			if (agent.remainingDistance == 0f)
			{

                Vector3 randomDirection = Random.insideUnitSphere * roamingRadius;
                randomDirection += startPosition;
                NavMeshHit hit;
                NavMesh.SamplePosition(randomDirection, out hit, roamingRadius, 1);
                Vector3 finalPosition = hit.position;

                agent.SetDestination(finalPosition);

            }
        }

        private void updateRange()
		{
			switch (rangeType)
			{
				case RangeType.close:
					attackRange = 1f;
					break;
				case RangeType.far:
					attackRange = 5f;
					break;
				case RangeType.both:
					attackRange = 4f;
					break;
			}
		}

		private void updateStates()
		{
			viewChecker(ref inView);
			distanceChecker();
			updateRange();
        }

        private void distanceChecker()
		{
			float distance = (transform.position - player.transform.position).magnitude;

			if (distance <= attackRange)
			{
				closeEnough = true;
			}
			else
			{
				closeEnough = false;
			}

			if (distance <= 3f && rangeType == RangeType.far)
			{
				toClose = true;
			}
			else if (rangeType == RangeType.far && distance > 3f)
			{
				toClose = false;
			}
		}

		private void viewChecker(ref bool inView)
		{
			//head.forward;

			Vector3 playerDirection = player.transform.position - head.transform.position;
			Vector3 forwardDirection = head.transform.forward;

			float angle = Vector3.Angle(forwardDirection, playerDirection);

			if (Mathf.Abs(angle) > 65)
			{
				inView = false;
			}
			else
			{
				inView = true;
			}
		}

		private void OnDrawGizmos()
		{
			Ray R1 = new Ray();
			R1.direction = head.transform.forward;
			R1.origin = head.transform.position;
			
			Gizmos.DrawRay(R1);


			Gizmos.DrawLine(head.position, player.transform.position);
		}
	}
}
