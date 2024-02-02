using SAOrpg.playerAPI.RPGstuff.StatsInventory;
//using UnityEditor;

namespace SAOrpg.Login
{
    [System.Serializable]
	public class saveData
	{
		public float[] position = new float[3];

		public int level;
		public float maxDamageSpeed;
		public int maxHealth;
		public float health;
		public float dashInterval;

		public int EXP;
		public int nextLevelEXP;

		public int levelPoints;
		public string displayName;

		public string[] weaponNames;
		public string[] itemNames;

		public string[] SkillskillType;
		public int[] Skilllevel;
		public int[] SkillEXP;
		public int[] SkillnextLevelEXP;

		public string UserName;
		public string password;

		public int col;

		public saveData(playerStats stats)
		{
			level = stats.level;
			maxHealth = stats.maxHealth;
			health = stats.health;
			EXP = stats.EXP;
			dashInterval = stats.dashInterval;
			nextLevelEXP = stats.nextLevelEXP;
			levelPoints = stats.levelPoints;
			displayName = stats.displayName;

            SkillskillType = new string[stats.skills.Length];
            Skilllevel = new int[stats.skills.Length];
            SkillEXP = new int[stats.skills.Length];
            SkillnextLevelEXP = new int[stats.skills.Length];

			col = stats.col;
			
			UserName = stats.UserName;
			password = stats.Encrypt(stats.Password);

			for (int i = 0; stats.skills.Length > i; i++)
			{
				SkillskillType[i] = stats.skills[i].skillType;
				Skilllevel[i] = stats.skills[i].level;
				SkillEXP[i] = stats.skills[i].EXP;
				SkillnextLevelEXP[i] = stats.skills[i].nextLevelEXP;
			}

			weaponNames = new string[stats.weapons.Length];
			itemNames = new string[stats.items.Length];

			
			for (int i = 0; i < stats.weapons.Length; i++)
			{
				//fuck this doesnt work
				//weaponNames[i] = AssetDatabase.GetAssetPath(stats.weapons[i]);
			}
			for (int i = 0; i < stats.items.Length; i++)
			{
				//itemNames[i] = AssetDatabase.GetAssetPath(stats.items[i]);
			}

			position[0] = stats.transform.position.x;
			position[1] = stats.transform.position.y;
			position[2] = stats.transform.position.z;
		}
	}
}
