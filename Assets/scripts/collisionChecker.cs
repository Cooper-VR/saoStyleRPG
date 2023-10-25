using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAOrpg.playerAPI
{
    public class collisionChecker : MonoBehaviour
    {
        #region collision states
        public bool entered;
        public bool exited;
        public bool currentlyTouching;
        #endregion

        //set the state values to the state of the collider
        private void OnTriggerEnter(Collider other)
        {
            entered = true;
        }

        private void OnTriggerExit(Collider other)
        {
            exited = true;
        }

        private void OnTriggerStay(Collider other)
        {
            currentlyTouching = true;
        }
    }
}

