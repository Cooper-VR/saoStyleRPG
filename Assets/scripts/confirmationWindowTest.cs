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
            //this is the window logic
            if (spawnWindow)
            {
                if (MasterInstance == null)
                {
                    //I would try to reference 1 window but muliple became an issue
                    MasterInstance = Instantiate(MasterPrefab, Vector3.zero,  Quaternion.identity, transform);
                }


                if (confirmationWindow.openWindow(MasterInstance.GetComponent<confirmationWindowMaster>(), text) == confirmationWindow.windowStates.no)
                {
                    Debug.Log("answered no");
                    confirmationWindow.closeWindow(MasterInstance);

                    //revert

                    spawnWindow = false;
                }else if (confirmationWindow.openWindow(MasterInstance.GetComponent<confirmationWindowMaster>(), text) == confirmationWindow.windowStates.yes)
                {
                    //do something

                    Debug.Log("answered yes");
                    confirmationWindow.closeWindow(MasterInstance);
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
