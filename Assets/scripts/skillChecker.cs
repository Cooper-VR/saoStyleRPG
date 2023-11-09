using SAOrpg.playerAPI;
using SAOrpg.playerAPI.RPGsstuff.inventory;
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

        private inventory inventory;

        public collisionChecker leftHandChecker;
        public collisionChecker rightHandChecker;
        public collisionChecker swordChecker;

        public bool skillActive;

        public MeshRenderer renderer;

        private void Start()
        {
            inventory = gameObject.GetComponent<inventory>();

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
            if (inventory.holdingObject != null)
            {
                renderer = inventory.holdingObject.transform.GetChild(0).gameObject.GetComponent<MeshRenderer>();
            }

            if (!skillActive)
            {
                for (int j = 0; j < renderer.materials.Length; j++)
                {
                    renderer.materials[j].SetFloat("_EmissionStrength", 0);
                    renderer.transform.GetChild(0).gameObject.SetActive(false);
                }
            }

            for(int i = 0; i < unlockedSkills.Count; i++)
            {
                //check collision data for left,right, sword
                //if the object name == the unlockedSkills[i].using_L/using_R for all 3:
                //set a bool to true

                if (rightHandChecker.collidedObject[2] == unlockedSkills[i].using_L[1] && leftHandChecker.collidedObject[2] == unlockedSkills[i].using_L[0] && leftHandChecker.collidedObject[2] == unlockedSkills[i].using_L[2])
                {
                    skillActive = true;

                    for (int j = 0; j < renderer.materials.Length; j++)
                    {
                        renderer.materials[j].SetFloat("_EmissionStrength", 1);
                        renderer.transform.GetChild(0).gameObject.SetActive(true);
                    }
                    //set sword color to the skillColor
                    //trail.setActive = true;
                }
            }
        }
    }
}
