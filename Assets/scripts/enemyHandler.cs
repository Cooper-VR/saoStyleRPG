using UnityEngine;
using UnityEngine.AI;

namespace SAOrpg.enemies
{
    public class enemyHandler : MonoBehaviour
    {
        public enemyScriptableObject enemyBehavior;
        public int health;
        public NavMeshAgent agent = new NavMeshAgent();

        private void Start()
        {
            health = enemyBehavior.health;
        }

        public void DealDamage(int amount)
        {
            health -= amount;
        }
    }
}
