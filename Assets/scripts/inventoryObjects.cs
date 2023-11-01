using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.inventory
{
    [CreateAssetMenu(fileName = "audioArrays", menuName = "ScriptableObjects/player/inventoryObjects", order = 1)]
    public class inventoryObjects : MonoBehaviour
    {
        public GameObject objectPrefab;
        public ObjectType objectType;

        public enum ObjectType
        {
            weapon,
            heal,
            item,
            armor
        }
    }
}
