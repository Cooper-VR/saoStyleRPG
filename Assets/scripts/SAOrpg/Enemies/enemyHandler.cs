using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using UnityEngine;
using UnityEngine.AI;
using SAOrpg.playerAPI.RPGstuff.Fighting;

namespace SAOrpg.enemies
{
    public class enemyHandler : MonoBehaviour
    {
        public enemyScriptableObject enemyBehavior;
        public int health;
        public NavMeshAgent agent = new NavMeshAgent();
        public GameObject damgerItem;

        private void Start()
        {
            health = enemyBehavior.health;
        }

        public void DealDamage(int amount)
        {
            health -= amount;

            if (health <= 0)
            {
                OnDeath();
            }
        }

        private void OnDeath()
        {
            damgerItem.GetComponent<PickupableObject>().alignmentObject.parent.GetComponent<playerStats>().incrementEXP(enemyBehavior.dropEXP);

            inventoryObjects[] playeritems = damgerItem.GetComponent<PickupableObject>().alignmentObject.parent.GetComponent<inventory>().items;

            inventoryObjects[] newItems = new inventoryObjects[playeritems.Length + 1];

            for (int i = 0; i < playeritems.Length; i++) 
            {
                newItems[i] = playeritems[i];
            }
            newItems[newItems.Length - 1] = enemyBehavior.itemDrops[Random.Range(0, enemyBehavior.itemDrops.Length)];
        }
    }
}
