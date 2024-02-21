using System.Collections;
using UnityEngine;
using SAOrpg.UI.Confirmation;
using SAOrpg.Login;
using SAOrpg.playerAPI.RPGstuff.StatsInventory;

namespace SAOrpg.UI.Buttons
{
    public class Logout : confirmationWindowInstaciatingClass
    {
        public void LogoutClick()
        {
            saveSystem.SavePlayer(GameObject.Find("[CameraRig]").GetComponent<playerStats>());
        }
    }
}
