using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking.Types;

namespace SAOrpg.playerAPI.RPGsstuff.audio
{
	public class walkSounds : MonoBehaviour
	{
		#region variables
		public soundArray[] soundArrays;

		private playerMovement movement;
		private dashing dashScript;

		public Vector2 velocity;


		public string[] soundMasks;
		public LayerMask allMasks;

		private int randomNum;

		public AudioSource audioSource;
		public AudioSource landSound;

		public float betweenSounds = 0.7f;
		public float currentTime;
		public float speedThreshold;



		#endregion

		private void Start()
		{
			movement = GetComponent<playerMovement>();
			dashScript = GetComponent<dashing>();
		}

		void Update()
		{
			

			velocity.x = movement.velocity.x;
			velocity.y = movement.velocity.z;

			if (velocity.magnitude > speedThreshold)
			{
				currentTime += 1 * Time.deltaTime;

				if (currentTime  >= betweenSounds / velocity.magnitude)
				{
					if (!dashScript.isDashing && movement.grounded)
					{
						//play sound
						randomNum = Random.Range(0, soundArrays[getCurrentLayer()].audio.Length);
						audioSource.clip = soundArrays[getCurrentLayer()].audio[randomNum];
						audioSource.Play();

						currentTime = 0f;
					}
				}
			}
			
		}

		//get the layer below the player
		private int getCurrentLayer()
		{
			Vector3 position = transform.position;
			position.y += 1;

			RaycastHit hit;

			string hitLayer;

			if (Physics.Raycast(position, Vector3.down, out hit, 3f, allMasks))
			{
				hitLayer = hit.transform.gameObject.tag;

				

				for (int i = 0; i < soundMasks.Length; i++)
				{
					if (hitLayer == soundMasks[i])
					{
						return i;
					}
				}
			}
			
			

			return -1;
			
		}
	}
}
