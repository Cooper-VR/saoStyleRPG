using SAOrpg.playerAPI.RPGsstuff.stats;

namespace SAOrpg
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


        //public levelingObject[] skills;

        //public inventoryObjects[] weapons;
        //public inventoryObjects[] items;

        public saveData(playerStats stats)
        {
            level = stats.level;
            maxHealth = stats.maxHealth;
            health = stats.health;
            EXP = stats.EXP;
            dashInterval = stats.dashInterval;
            nextLevelEXP = stats.nextLevelEXP;
            levelPoints = stats.levelPoints;
            //skills = stats.skills;
            //weapons = stats.weapons;
            //items = stats.items;

            position[0] = stats.transform.position.x;
            position[1] = stats.transform.position.y;
            position[2] = stats.transform.position.z;
        }
    }
}
