using SAOrpg.playerAPI.RPGsstuff;
using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.playerColliders
{
    public class Damager : MonoBehaviour
    {
        #region variables
        public DamageColliderHandler DamageColliderHandler;
        private collisionChecker[] playerColliders = new collisionChecker[5];
        private playerStats stats;
        public bool hit;

        #endregion


        private void Start()
        {
            
        }

        private void FixedUpdate()
        {
            //gets the collision check scripts
            playerColliders[0] = DamageColliderHandler.torsoCheck;
            playerColliders[1] = DamageColliderHandler.leftLegCheck;
            playerColliders[2] = DamageColliderHandler.rightLegCheck;
            playerColliders[3] = DamageColliderHandler.leftArmCheck;
            playerColliders[4] = DamageColliderHandler.rightArmCheck;

            //check if one of them is hit
            for (int i = 0; i < playerColliders.Length; i++)
            {
                if (playerColliders[i].collidedGameobject.tag.Contains("Enemy"))
                {
                    hit = playerColliders[i].currentlyTouching;
                }
            }

            if (hit)
            {

                stats.health -= 10;
                hit = false;

                //-10
            }
        }
    }
}

