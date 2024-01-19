using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.UI
{
    public class confirmationWindowMaster : MonoBehaviour
    {
        public confirmationWindowControl window;
        public GameObject confirm;
        // Start is called before the first frame update
        void Start()
        {
            window = Instantiate(confirm, Vector3.zero, Quaternion.identity, transform).GetComponent<confirmationWindowControl>();
            confirmationWindow.closeWindow();
        }

        // Update is called once per frame
        void Update()
        {
        
        }
    }
}
