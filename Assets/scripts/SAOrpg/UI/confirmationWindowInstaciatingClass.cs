using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindowInstaciatingClass : MonoBehaviour
    {
        public GameObject confirmationWindow;
        public string windowText;
        public string methodName;

        private confirmationWindowLogic confirmationWindowLogic;

        public void OpenTheWindow()
        {
            confirmationWindowLogic = Instantiate(confirmationWindow, Vector3.zero, confirmationWindow.transform.rotation).GetComponent<confirmationWindowLogic>();

            confirmationWindowLogic.rootButton = gameObject;
            confirmationWindowLogic.text = windowText;
            confirmationWindowLogic.methodName = methodName;
        }
    }
}
