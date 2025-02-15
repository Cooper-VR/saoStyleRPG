using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI.Confirmation
{
    public class confirmationWindowInstaciatingClass : MonoBehaviour
    {
        [Tooltip("use prefab called windowLogic")]
        public GameObject confirmationWindow;
        public string windowText;
        public string methodName;

        public confirmationWindowLogic confirmationWindowLogic;

        public void OpenTheWindow()
        {
            confirmationWindowLogic = Instantiate(confirmationWindow, Vector3.zero, confirmationWindow.transform.rotation).GetComponent<confirmationWindowLogic>();

            confirmationWindowLogic.rootButton = gameObject;
            confirmationWindowLogic.text = windowText;
            confirmationWindowLogic.methodName = methodName;
        }
    }
}
