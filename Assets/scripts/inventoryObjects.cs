using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    [CreateAssetMenu(fileName = "inventoryObject", menuName = "ScriptableObjects/player/inventoryObjects", order = 3)]
    public class inventoryObjects : ScriptableObject
    {
        public GameObject objectPrefab;
        public ObjectType objectType;
        public string objectName;

        public enum ObjectType
        {
            weapon,
            item
        }
    }
}
