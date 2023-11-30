using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg
{
    [CreateAssetMenu(fileName = "enemy", menuName = "ScriptableObjects/enemy/enemy", order = 0)]
    public class enemyScriptableObject : ScriptableObject
    {
        public generalBehavior behavior;
        public int RunSpeed;
        public int WalkSpeed;
        public int health;

        public enum generalBehavior
        {
            Passisve,
            agressive,
            runaway,
            friendly

        }
    }
}
