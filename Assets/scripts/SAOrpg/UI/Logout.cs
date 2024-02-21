using System.Collections;
using UnityEngine;
using SAOrpg.UI.Confirmation;
using SAOrpg.Login;
using SAOrpg.playerAPI.RPGstuff.StatsInventory;

namespace SAOrpg.UI
{
    public class Logout : confirmationWindowInstaciatingClass
    {
        private void Start()
        {
            OpenTheWindow();
        }

        public void LogoutClick()
        {
            saveSystem.SavePlayer(GameObject.Find("[CameraRig]").GetComponent<playerStats>());
        }
    }
}
