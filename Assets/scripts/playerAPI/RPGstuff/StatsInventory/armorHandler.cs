using System;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.Armor
{
    public class armorHandler : MonoBehaviour
    {
        public GameObject player;

        private GameObject upperOBJ;
        private GameObject lowerOBJ;

        private GameObject currentUpper;
        private GameObject currentLower;

        private GameObject previousUpper;
        private GameObject previousLower;

        public Animator armorObject1;
        public Transform[] armorBonesArray1;

        public Animator armorObject2;
        public Transform[] armorBonesArray2;

        private Animator sourceObject;
        private Transform[] sourceBonesArray;

        private void Start()
        {
            sourceObject = transform.parent.gameObject.GetComponent<Animator>();
        }

        private void Update()
        {
            upperOBJ = player.GetComponent<inventory.inventory>().upperArmor.objectPrefab;
            lowerOBJ = player.GetComponent<inventory.inventory>().lowerArmor.objectPrefab;

            if (transform.childCount != 2)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }

                currentUpper = Instantiate(upperOBJ, transform.position, transform.rotation, transform);
                currentLower = Instantiate(lowerOBJ, transform.position, transform.rotation, transform);
            }

            if (previousUpper != upperOBJ || previousLower != lowerOBJ)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    Destroy(transform.GetChild(i).gameObject);
                }

                currentUpper = Instantiate(upperOBJ, transform.position, transform.rotation, transform);
                currentLower = Instantiate(lowerOBJ, transform.position, transform.rotation, transform);

                //get rotation offsets (for fingers)
            }

            armorObject1 = currentUpper.GetComponent<Animator>();
            armorObject2 = currentLower.GetComponent<Animator>();

            previousUpper = upperOBJ;
            previousLower = lowerOBJ;

            hideParts();

            setTransform();
            getBones();
            armorObject1.GetBoneTransform(HumanBodyBones.Hips).position = sourceObject.GetBoneTransform(HumanBodyBones.Hips).position;
            armorObject2.GetBoneTransform(HumanBodyBones.Hips).position = sourceObject.GetBoneTransform(HumanBodyBones.Hips).position;
        }

        private void hideParts()
        {
            
            for (int i = 0; i < armorObject1.transform.childCount; i++)
            {
                if (!armorObject1.transform.GetChild(i).name.ToLower().Contains("upper") && armorObject1.transform.GetChild(i).name != "Armature")
                {
                    armorObject1.transform.GetChild(i).gameObject.SetActive(false);
                }
            }

            for (int i = 0; i < armorObject2.transform.childCount; i++)
            {
                if (!armorObject2.transform.GetChild(i).name.ToLower().Contains("lower") && armorObject2.transform.GetChild(i).name != "Armature")
                {
                    armorObject2.transform.GetChild(i).gameObject.SetActive(false);
                }
            }
        }

        private void getBones()
        {
            HumanBodyBones[] boneEnumValues = (HumanBodyBones[])Enum.GetValues(typeof(HumanBodyBones));
            armorBonesArray1 = new Transform[boneEnumValues.Length];

            for (int i = 0; i < 55; i++)
            {
                armorBonesArray1[i] = armorObject1.GetBoneTransform(boneEnumValues[i]);
            }

            armorBonesArray2 = new Transform[boneEnumValues.Length];

            for (int i = 0; i < 55; i++)
            {
                armorBonesArray2[i] = armorObject2.GetBoneTransform(boneEnumValues[i]);
            }

            sourceBonesArray = new Transform[boneEnumValues.Length];

            for (int i = 0; i < 55; i++)
            {
                sourceBonesArray[i] = sourceObject.GetBoneTransform(boneEnumValues[i]);
            }
        }

        private void setTransform()
        {
            for (int i = 0; i < armorBonesArray1.Length;i++)
            {
                if (armorBonesArray1[i] != null)
                {
                    armorBonesArray1[i].rotation = sourceBonesArray[i].rotation;
                }
                
            }

            for (int i = 0; i < armorBonesArray2.Length; i++)
            {
                if (armorBonesArray2[i] != null)
                {
                    armorBonesArray2[i].rotation = sourceBonesArray[i].rotation;
                }

            }
        }
    }
}
