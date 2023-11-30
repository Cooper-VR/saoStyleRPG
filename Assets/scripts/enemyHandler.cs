using UnityEngine;
using UnityEngine.AI;

namespace SAOrpg.enemies
{
    public class enemyHandler : MonoBehaviour
    {
        public enemyScriptableObject enemyBehavior;

        public NavMeshAgent agent = new NavMeshAgent();


        public void DealDamage(int amount)
        {
            enemyBehavior.health -= amount;
        }
    }
}
