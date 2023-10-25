using SAOrpg.playerAPI.RPGsstuff;
using SAOrpg.playerAPI.RPGsstuff.audio;
using UnityEngine;

namespace SAOrpg.playerAPI
{
    public class dashing : MonoBehaviour
    {
        private playerMovement movementScript;
        private playerStats stats;
        public Vector3 dashDirection;
        public float dashSpeed;


        private float currentIntervalTime;
        private float currentWaitTime;
        public bool isDashing = false;
        private bool dashReady;
        private float dashTime;
        public AudioSource dashAudio;

        

        private void Start()
        {
            movementScript = GetComponent<playerMovement>();
            stats = GetComponent<playerStats>();
        }

        private void FixedUpdate()
        {
            if (movementScript.velocity == Vector3.zero)
            {
                dashDirection = movementScript.camera.forward;
            }
            else
            {
                dashDirection = movementScript.velocity;
            }

            dashDirection *= dashSpeed;

            if (dashReady && false)
            {
                //do the dash
                dashAudio.Play();
                dashReady = false;
                isDashing = true;
            }

            if (isDashing)
            {
                currentIntervalTime += Time.deltaTime;
                movementScript.velocity = dashDirection * dashSpeed;
            }
            if (currentIntervalTime >= dashTime)
            {
                isDashing = false;
                currentIntervalTime = 0;
            }

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
    }
}
