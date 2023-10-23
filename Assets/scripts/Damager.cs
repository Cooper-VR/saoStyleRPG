using SAOrpg.playerAPI.RPGsstuff;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff
{
    public class Damager : MonoBehaviour
    {
        public DamageColliderHandler DamageColliderHandler;

        private collisionChecker[] playerColliders = new collisionChecker[5];

        private void Start()
        {
            playerColliders[0] = DamageColliderHandler.torsoCheck;
            playerColliders[0] = DamageColliderHandler.leftLegCheck;
            playerColliders[0] = DamageColliderHandler.rightLegCheck;
            playerColliders[0] = DamageColliderHandler.leftArmCheck;
            playerColliders[0] = DamageColliderHandler.rightArmCheck;
        }

        private void FixedUpdate()
        {
            
        }
    }
}

