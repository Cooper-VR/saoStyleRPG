using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using SAOrpg.playerAPI.RPGstuff.Movement;

namespace SAOrpg.UI
{
    public class healthBarHandler : MonoBehaviour
	{
		public GameObject playerObject;

		public TMP_Text currentHealth;
		public TMP_Text totalHealth;

		public TMP_Text level;
		public Gradient healthGradient;
		public GameObject scalarObject;

		public Image healthValue;
		private playerStats playerStats;

		private void Start()
		{
			playerStats = playerObject.GetComponent<playerStats>();
		}

		private void Update()
		{
			level.text = playerStats.level.ToString();
			totalHealth.text = playerStats.maxHealth.ToString();
			currentHealth.text = playerStats.health.ToString();

			healthValue.color = healthGradient.Evaluate(playerStats.health / playerStats.maxHealth);
			scalarObject.transform.localScale = new Vector3 (playerStats.health / playerStats.maxHealth, playerStats.health / playerStats.maxHealth, 1);

        }

        private void FixedUpdate()
        {
			//followPlayer();
        }

        private void followPlayer()
		{
			playerMovement movement = playerObject.GetComponent<playerMovement>();
			transform.position = movement.camera.transform.position;
			transform.rotation = movement.camera.rotation;
        }
	}
}
