using SAOrpg.playerAPI.RPGsstuff.inventory;
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

        public inventoryObjects[] weapons;
        public inventoryObjects[] items;

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

        public void savePlayer()
        {
            saveSystem.SavePlayer(this);
        }
        public void loadPlayer()
        {
            saveData data = saveSystem.LoadPlayer();

            level = data.level;
            maxHealth = data.maxHealth;
            health = data.health;
            EXP = data.EXP;
            dashInterval = data.dashInterval;
            nextLevelEXP = data.nextLevelEXP;
            levelPoints = data.levelPoints;
            //skills = data.skills;
            //weapons = data.weapons;
            //items = data.items;

            Vector3 position = new Vector3();

            position.x = data.position[0];
            position.y = data.position[1];
            position.z = data.position[2];

            Debug.Log(position);

            GetComponent<playerMovement>().enabled = false;

            transform.position = position;

            GetComponent<playerMovement>().enabled = true;
        }
    }
}

