using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
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
	}
}
