using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

namespace SAOrpg.playerAPI.RPGsstuff.audio
{
    public class walkSounds : MonoBehaviour
    {
        public soundArray[] soundArrays;

        public bool airTime;

        private playerMovement movement;
        private dashing dashScript;

        public Vector3 velocity;
        public float speed;
        public float offset = 0.5f;

        public Vector3 playerPosition;

        public float dashWait;
        public float betweenAudio;
        public float audioCoolDown = 0f;

        public LayerMask[] soundMasks;

        private int randomNum;

        public AudioSource audioSource;
        public AudioSource landSound;

        [ExecuteInEditMode]
        private void Start()
        {
            movement = gameObject.GetComponent<playerMovement>();
            dashScript = gameObject.GetComponent<dashing>();
            audioSource = gameObject.GetComponent<AudioSource>();
            soundMasks = new LayerMask[soundArrays.Length];
        }

        void Update()
        {

            if (dashScript.isDashing == true)
            {
                dashWait = 0.2f;
            }
            if (dashScript.isDashing == false)
            {
                dashWait = dashWait - 1 * Time.deltaTime;

            }
            audioSource = GetComponent<AudioSource>();
            betweenAudio = betweenAudio + 1 * Time.deltaTime;
            if (betweenAudio > 20)
            {
                audioCoolDown = 0;
                betweenAudio = 0;
            }

            if (movement.grounded == false)
            {
                audioSource.enabled = false;
                airTime = true;

            }
            else if (movement.grounded == true)
            {
                if (audioCoolDown < -0.6)
                {
                    landSound.Play();
                    betweenAudio = 0;
                }
                airTime = false;
                audioSource.enabled = true;
                audioCoolDown = 0;
            }

            if (airTime == true)
            {
                audioCoolDown = audioCoolDown - 1 * Time.deltaTime;
            }



            playerPosition = transform.position;

            velocity = movement.GetVelocity();

            speed = Mathf.Sqrt(Mathf.Pow(velocity.x, 2) + Mathf.Pow(velocity.y, 2) + Mathf.Pow(velocity.z, 2));
            if (speed > 1.9f && speed < 3.1f && movement.grounded == true)
            {
                if (offset <= 0)
                {
                    randomNum = Random.Range(0, soundArrays[getCurrentLayer()].audio.Length);
                    audioSource.clip = soundArrays[getCurrentLayer()].audio[randomNum];
                    audioSource.Play();
                    offset = 0.5f;
                }

                offset = offset - 1 * Time.deltaTime;
            }
            
        }

        private int getCurrentLayer()
        {
            Vector3 position = transform.position;
            position.y += 1;

            for (int i = 0; i < soundMasks.Length; i++)
            {
                if (Physics.Raycast(position, Vector3.down, 3f, soundMasks[i]))
                {
                    return i;
                }
            }
            return -1;
            
        }
    }
}
