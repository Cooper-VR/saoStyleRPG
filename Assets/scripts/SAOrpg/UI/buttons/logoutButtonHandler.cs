using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using UnityEngine;
using SAOrpg.Login;

namespace SAOrpg.playerAPI.RPGstuff.Menu
{
    public class logoutButtonHandler : MonoBehaviour
    {
        public bool isLogout;
        private collisionChecker collisionChecker;
        private playerStats stats;

        private void Start()
        {
            stats = GameObject.Find("[CameraRig]").GetComponent<playerStats>();
            collisionChecker = GetComponent<collisionChecker>();
        }

        private void Update()
        {
            if (isLogout && collisionChecker.entered && collisionChecker.collidedObject.Contains("finger"))
            {
                saveSystem.SavePlayer(stats);

                Destroy(transform.parent.parent.gameObject);
            }
            else if (collisionChecker.entered && collisionChecker.collidedObject.Contains("finger"))
            {
                Destroy(transform.parent.parent.gameObject);
            }
        }
    }
}
