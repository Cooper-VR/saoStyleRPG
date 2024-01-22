using UnityEngine;

namespace SAOrpg.playerAPI.RPGstuff.StatsInventory
{
    [CreateAssetMenu(fileName = "inventoryObject", menuName = "ScriptableObjects/player/inventoryObjects", order = 3)]
    public class inventoryObjects : ScriptableObject
    {
        public GameObject objectPrefab;
        public ObjectType objectType;
        public string objectName;


        [Header("these are weapon exlusive")]
        public int maxDamage;

        public enum ObjectType
        {
            weapon,
            item
        }
    }
}
