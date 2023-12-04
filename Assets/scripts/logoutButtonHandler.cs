using SAOrpg.playerAPI;
using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
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
            if (isLogout && collisionChecker.exited)
            {
                saveSystem.SavePlayer(stats);
            }
            else if (collisionChecker.exited)
            {
                Destroy(transform.parent.parent.gameObject);
            }
        }
    }
}
