using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI.Buttons
{
    public class LogoutButton : buttonHandler
    {

        public GameObject logoutPrefab;

        public override void ButtonAction()
        {
            Instantiate(logoutPrefab);
            isPressed = false;
            DoActionOn();
        }
        public override void PressedAction()
        {
            throw new System.NotImplementedException();
        }
    }
}
