using System;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.Armor
{
    public class armorHandler : MonoBehaviour
    {
        public Animator armorObject;
        public Transform[] armorBonesArray;

        public Animator sourceObject;
        public Transform[] sourceBonesArray;

        private void Start()
        {
            getBones();
        }

        private void Update()
        {
            setTransform();
        }

        private void getBones()
        {
            HumanBodyBones[] boneEnumValues = (HumanBodyBones[])Enum.GetValues(typeof(HumanBodyBones));
            armorBonesArray = new Transform[boneEnumValues.Length];

            for (int i = 0; i < 55; i++)
            {
                armorBonesArray[i] = armorObject.GetBoneTransform(boneEnumValues[i]);
            }

            sourceBonesArray = new Transform[boneEnumValues.Length];

            for (int i = 0; i < 55; i++)
            {
                sourceBonesArray[i] = sourceObject.GetBoneTransform(boneEnumValues[i]);
            }
        }

        private void setTransform()
        {
            for (int i = 0; i < armorBonesArray.Length;i++)
            {
                if (armorBonesArray[i] != null)
                {
                    armorBonesArray[i].rotation = sourceBonesArray[i].rotation;
                }
                
            }
        }
    }
}
