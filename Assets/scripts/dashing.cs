using SAOrpg.playerAPI.RPGsstuff;
using SAOrpg.playerAPI.RPGsstuff.audio;
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
        private float dashTime;
        private playerMovement movementScript;
        private playerStats stats;
        #endregion

        #region start/update
        private void Start()
        {
            //get player scripts
            movementScript = GetComponent<playerMovement>();
            stats = GetComponent<playerStats>();
        }

        private void FixedUpdate()
        {
            //check if the player is moving
            if (movementScript.velocity == Vector3.zero)
            {
                dashDirection = movementScript.camera.forward;
            }
            else
            {
                dashDirection = movementScript.velocity;
            }

            //
            dashDirection *= dashSpeed * Time.fixedDeltaTime;

            //proform dashing
            if (dashReady && false)
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
                movementScript.velocity = dashDirection * dashSpeed;
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
