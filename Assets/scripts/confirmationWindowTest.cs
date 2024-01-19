using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindowTest : MonoBehaviour
    {
        public bool spawnWindow;
        public GameObject MasterPrefab;
        public GameObject MasterInstance;

        public string text;

        private void Update()
        {
            if (spawnWindow)
            {
                if (MasterInstance == null)
                {
                    MasterInstance = Instantiate(MasterPrefab, Vector3.zero,  Quaternion.identity, transform);
                }


                if (confirmationWindow.openWindow(MasterInstance.GetComponent<confirmationWindowMaster>(), text) == confirmationWindow.windowStates.no)
                {
                    Debug.Log("answered no");
                    confirmationWindow.closeWindow();
                    spawnWindow = false;
                }else if (confirmationWindow.openWindow(MasterInstance.GetComponent<confirmationWindowMaster>(), text) == confirmationWindow.windowStates.yes)
                {
                    Debug.Log("answered yes");
                    confirmationWindow.closeWindow();
                    spawnWindow = false;
                }
                else
                {
                    Debug.Log("undecided");
                }
            }
        }
    }
}
