using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindowMaster : MonoBehaviour
    {
        public confirmationWindowControl window;
        // Start is called before the first frame update
        void Start()
        {
            window = GameObject.Find("ConfirmationWindowPrefab").GetComponent<confirmationWindowControl>();
            confirmationWindow.closeWindow();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
