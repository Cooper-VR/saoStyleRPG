using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using SAOrpg.UI;
using TMPro;
using UnityEngine;

namespace SAOrpg.NPCs.Menu
{
    public class itemButton : confirmationWindowInstaciatingClass
    {
        public TMP_Text cost;
        public TMP_Text item;

        public string itemCost;
        public string itemName;

        public inventoryObjects itemPrefab;

        private inventory inventory;
        private playerStats stats;

        collisionChecker collisionChecker;
        bool opened;

        private void Start()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<inventory>();
            stats = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<playerStats>();

            collisionChecker = GetComponent<collisionChecker>();

            itemCost = $"{itemPrefab.cost.ToString()} col";
            itemName = itemPrefab.objectName;

            cost.text = itemCost;
            item.text = itemName;
        }

        private void Update()
        {
            if (collisionChecker.entered && collisionChecker.collidedObject.Contains("finger"))
            {
                //do action
                if (opened)
                {
                    opened = false;
                    OpenTheWindow();
                }
                if (!opened)
                {
                    opened = true;           
                }
            }
        }

        public void addToInventory()
        {
            if (stats.col < int.Parse(itemCost))
            {
                Debug.Log("not enough");
            }
            else
            {
                if (itemPrefab.objectType == inventoryObjects.ObjectType.weapon)
                {
                    inventory.weapons.Add(itemPrefab);
                }
                else
                {
                    inventory.items.Add(itemPrefab);
                }
                stats.col -= int.Parse(itemCost);
            }
        }
    }
}
