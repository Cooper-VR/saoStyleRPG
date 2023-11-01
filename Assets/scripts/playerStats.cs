using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.stats
{
    public class playerStats : MonoBehaviour
    {
        public int level;
        public float maxDamageSpeed;
        public int maxHealth;
        public float health;
        public float dashInterval;

        public int EXP;
        public int nextLevelEXP;

        public int levelPoints;


        public levelingObject[] skills;

        

        public void incrementLevel()
        {
            level++;
            levelPoints++;

            maxHealth = Mathf.RoundToInt(Mathf.Pow(1.104f, level) + 249);
        }

        public void incrementEXP(int increaseAmount)
        {
            EXP += increaseAmount;

            while (EXP >= nextLevelEXP)
            {
                EXP -= nextLevelEXP;

                nextLevelEXP += 50;

                incrementLevel();
            }
        }

        public void usePoint(levelingObject skill)
        {
            if (levelPoints > 0)
            {
                skill.incrementLevel();
                levelPoints--;
            }
        }
    }
}

