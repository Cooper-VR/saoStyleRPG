using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAOrpg.playerAPI
{
    public class collisionChecker : MonoBehaviour
    {
        public bool entered;
        public bool exited;
        public bool currentlyTouching;

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

