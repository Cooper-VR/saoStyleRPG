using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.Movement
{
    public class walkSounds : MonoBehaviour
	{
		#region variables

		public TerrainLayer[] terrainLayers;

		public int surfaceIndex = 0;

		public Terrain terrain;
		private TerrainData terrainData;
		private Vector3 terrainPos;

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
            terrainData = terrain.terrainData;
            terrainPos = terrain.transform.position;

            movement = GetComponent<playerMovement>();
			dashScript = GetComponent<dashing>();
		}

		void Update()
		{

            surfaceIndex = GetMainTexture(transform.position);

            velocity.x = movement.velocity.x;
			velocity.y = movement.velocity.z;

			if (velocity.magnitude > speedThreshold)
			{
				currentTime += 1 * Time.deltaTime;

				if (currentTime >= betweenSounds / velocity.magnitude)
				{
					if (!dashScript.isDashing && movement.grounded)
					{
						//play sound
						try {
                            randomNum = UnityEngine.Random.Range(0, soundArrays[getCurrentLayer()].audio.Length);
                            audioSource.clip = soundArrays[getCurrentLayer()].audio[randomNum];
                            audioSource.Play();

                            currentTime = 0f;
                        }
						catch
						{
							Debug.Log("in air");
						}
						
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

				if (hitLayer == "Terrain")
				{
                    
					return surfaceIndex;
                }

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

		private float[] GetTextureMix(Vector3 worldPos)
		{
			// returns an array containing the relative mix of textures
			// on the main terrain at this world position.

			// The number of values in the array will equal the number
			// of textures added to the terrain.

			// calculate which splat map cell the worldPos falls within (ignoring y)
			int mapX = (int)(((worldPos.x - terrainPos.x) / terrainData.size.x) * terrainData.alphamapWidth);
			int mapZ = (int)(((worldPos.z - terrainPos.z) / terrainData.size.z) * terrainData.alphamapHeight);

			// get the splat data for this cell as a 1x1xN 3d array (where N = number of textures)
			float[,,] splatmapData = terrainData.GetAlphamaps(mapX, mapZ, 1, 1 );

			// extract the 3D array data to a 1D array:
			float[] cellMix = new float[splatmapData.GetUpperBound(2) + 1];
		
			for (int n = 0; n < cellMix.Length; n ++ )
			{
				cellMix[n] = splatmapData[0, 0, n];
			}
	
			return cellMix;
		}


	private int GetMainTexture(Vector3 worldPos)
	{
		// returns the zero-based index of the most dominant texture
		// on the main terrain at this world position.
		float[] mix  = GetTextureMix(worldPos);

        float maxMix = 0;
        int maxIndex = 0;

		// loop through each mix value and find the maximum
		for (int n = 0; n < mix.Length; n++ )
		{
			if (mix[n] > maxMix)
			{
				maxIndex = n;
				maxMix = mix[n];
			}
		}

		return maxIndex;
		}
	}
}
