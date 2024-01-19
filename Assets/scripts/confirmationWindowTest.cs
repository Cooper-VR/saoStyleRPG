using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindowTest : MonoBehaviour
    {
        public bool spawnWindow;

        private void Update()
        {
            if (spawnWindow)
            {
                confirmationWindow.openWindow(this, "testMessage");

                if (confirmationWindow.openWindow(this, "testMessage") == confirmationWindow.windowStates.no)
                {
                    Debug.Log("answered no");
                    confirmationWindow.closeWindow();
                }else if (confirmationWindow.openWindow(this, "test message") == confirmationWindow.windowStates.yes)
                {
                    Debug.Log("answered yes");
                    confirmationWindow.closeWindow();
                }
                else
                {
                    Debug.Log("undecided");
                }
            }
        }
    }
}
