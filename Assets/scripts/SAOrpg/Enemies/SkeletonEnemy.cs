using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SAOrpg
{
    public class SkeletonEnemy : MonoBehaviour
    {
        public float health = 250f;

        public GameObject player;
        private Animator animator;
        public float Distance;
        public float attackCD = 3f;
        public float attackRange = 1f;
        public float agroRange = 4f;

        private NavMeshAgent agnet;
        float timePassed;
        float newDestinationCD = 0.5f;

        private void Update()
        {
            Distance = Vector3.Distance(player.transform.position, transform.position);
            animator.SetFloat("Speed", agnet.velocity.magnitude/agnet.speed);

            if (timePassed >= attackCD)
            {
                if (Vector3.Distance(player.transform.position, transform.position) <= attackRange)
                {
                    animator.SetTrigger("attack");
                    timePassed = 0;
                }
            }
            timePassed += Time.deltaTime;

            if (newDestinationCD <=0 && Vector3.Distance(player.transform.position, transform.position) <= agroRange)
            {
                newDestinationCD = 0.5f;
                agnet.SetDestination(player.transform.position);
            }
            newDestinationCD -= Time.deltaTime;
            //transform.LookAt(player.transform);
        }

        private void Start()
        {
            agnet = GetComponent<NavMeshAgent>();
            animator = GetComponent<Animator>();
            //player = GameObject.FindWithTag("Player");
        }

        public void TakeDamge(float damageAmount)
        {
            health -= damageAmount;

            animator.SetTrigger("damage");

            if (health <= 0)
            {
                Die();
            }
        }

        private void Die()
        {
            Destroy(gameObject);
        }
    }
}
