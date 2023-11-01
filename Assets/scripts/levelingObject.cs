using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.stats
{
    [CreateAssetMenu(fileName = "audioArrays", menuName = "ScriptableObjects/player/skill", order = 1)]
    public class levelingObject : ScriptableObject
    {
        public string skillType;
        public int level;
        public int EXP;
        public int nextLevelEXP;

        public void incrementLevel()
        {
            level++;
        }
        public void incrementEXP(int increaseAmount)
        {
            EXP += increaseAmount;

            while (EXP > nextLevelEXP)
            {
                EXP -= nextLevelEXP;

                incrementLevel();
            }
        }
    }
}
