using SAOrpg.playerAPI;
using SAOrpg.playerAPI.RPGsstuff.stats;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg
{
    public class skillChecker : MonoBehaviour
    {
        public poseDirectionObject[] allSkills;
        public int[] unlockLevels;

        public List<poseDirectionObject> unlockedSkills = new List<poseDirectionObject>();

        public collisionChecker leftHandChecker;
        public collisionChecker rightHandChecker;
        public collisionChecker swordChecker;

        public bool skillActive;

        private void Start()
        {
            for (int i = 0; i < allSkills.Length; i++)
            {
                //poseDirection has levelThreshold, get poseDirection.skillLevel, check if the poseDirection is > threshold, if so, add to unlocked
                if (allSkills[i].unlockLevel >= allSkills[i].skillType.level)
                {
                    unlockedSkills.Add(allSkills[i]);
                }
            }
        }

        private void Update()
        {
            for(int i = 0; i < unlockedSkills.Count; i++)
            {
                //check collision data for left,right, sword
                //if the object name == the unlockedSkills[i].using_L/using_R for all 3:
                //set a bool to true

                if (rightHandChecker.collidedObject[2] == unlockedSkills[i].using_L[1] && leftHandChecker.collidedObject[2] == unlockedSkills[i].using_L[0] && leftHandChecker.collidedObject[2] == unlockedSkills[i].using_L[2])
                {
                    skillActive = true;
                }
            }
        }
    }
}
