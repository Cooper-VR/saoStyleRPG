using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;

namespace SAOrpg.playerAPI
{
    public class dashing : MonoBehaviour
    {
        #region variables
        
        public Vector3 dashDirection;
        public float dashSpeed;
        public AudioSource dashAudio;
        public bool isDashing = false;

        private float currentIntervalTime;
        private float currentWaitTime;
        private bool dashReady;
        public float dashTime;

        private playerMovement movementScript;
        private playerStats stats;
        #endregion

        #region start/update
        private void Start()
        {
            //get player scripts
            dashSpeed = GetComponent<playerStats>().skills[0].level * 1.6f;
            movementScript = GetComponent<playerMovement>();
            stats = GetComponent<playerStats>();
        }

        private void FixedUpdate()
        {
            dashDirection = movementScript.velocity.normalized;
            dashDirection.y = 0;
            dashDirection = dashDirection.normalized;

            if (dashDirection.magnitude == 0f)
            {
                dashDirection = movementScript.camera.forward;
            }
            

            //proform dashing
            if (dashReady && Input.GetButton("Fire1"))
            {
                //do the dash
                dashAudio.Play();
                dashReady = false;
                isDashing = true;
            }

            //do while player is dashing
            if (isDashing)
            {
                currentIntervalTime += Time.deltaTime;
                dashDirection *= dashSpeed;
                movementScript.velocityAddon = dashDirection;
                
                
            }
            //check if their time is up
            if (currentIntervalTime >= dashTime)
            {
                isDashing = false;
                currentIntervalTime = 0;
            }

            //do after the player finished dashing
            if (!isDashing)
            {
                currentWaitTime += Time.deltaTime;
                movementScript.velocityAddon = Vector3.zero;
            }
            if (currentWaitTime >= stats.dashInterval)
            {
                dashReady = true;
                currentWaitTime = 0;
            }
        }
        #endregion
    }
}
