using SAOrpg.playerAPI.RPGsstuff;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.playerColliders
{
    public class Damager : MonoBehaviour
    {
        #region variables
        public DamageColliderHandler DamageColliderHandler;
        private collisionChecker[] playerColliders = new collisionChecker[5];

        public bool hit;
        #endregion


        private void Start()
        {
            //gets the collision check scripts
            playerColliders[0] = DamageColliderHandler.torsoCheck;
            playerColliders[1] = DamageColliderHandler.leftLegCheck;
            playerColliders[2] = DamageColliderHandler.rightLegCheck;
            playerColliders[3] = DamageColliderHandler.leftArmCheck;
            playerColliders[4] = DamageColliderHandler.rightArmCheck;
        }

        private void FixedUpdate()
        {
            //check if one of them is hit
            for (int i = 0; i < playerColliders.Length; i++)
            {
                hit = playerColliders[i].currentlyTouching;
            }
        }
    }
}

