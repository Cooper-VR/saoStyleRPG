using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

namespace SAOrpg
{
    public class chuchuController : MonoBehaviour
    {
        public NavMeshAgent agent;
        public Animator animator;
        public Transform player;

        [Header("bool states")]
        public bool attacking;
        public bool closeEnough;
        public bool hit;



        private void Update()
        {
            setBools();

            if ((transform.position - player.position).magnitude < 3f && (transform.position - player.position).magnitude > 0.3f)
            {
                closeEnough = false;

                if (!attacking)
                {
                    agent.SetDestination(player.position);
                }
            }else if ((transform.position - player.position).magnitude <= 0.3)
            {
                closeEnough = true;
            }
            else
            {
                closeEnough = false;
            }

            if (closeEnough)
            {
                attacking = true;
            }
        }

        private void setBools()
        {
            animator.SetBool("attacking", attacking);
        }

        private void OnTriggerEnter(Collider other)
        {
            if (attacking && other.tag == "Player")
            {
                //deal damge to player
            }else if (!attacking)
            {
                //take damage
                animator.SetBool("hit", hit);
            }
        }

        public void attackFinished()
        {
            attacking = false;
        }
    }
}
