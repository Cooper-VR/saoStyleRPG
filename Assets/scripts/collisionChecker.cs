using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace SAOrpg.playerAPI
{
    public class collisionChecker : MonoBehaviour
    {
        #region collision states
        public string collidedObject;
        public GameObject collidedGameobject;

        public bool entered;
        public bool exited;
        public bool currentlyTouching;

        private float currentTime1;
        private float currentTime2;
        #endregion

        private void Update()
        {
            if (collidedObject == "")
            {
                entered = false;
                currentlyTouching = false;
                collidedGameobject = null;
            }

            if (entered)
            {
                currentTime1 += Time.deltaTime;
            }

            if (currentTime1 >= 1)
            {
                //entered = false;
            }

            if (exited)
            {
                currentTime2 += Time.deltaTime;
            }
            if (currentTime2 >= 1)
            {
                exited = false;
            }
        }

        //set the state values to the state of the collider
        private void OnTriggerEnter(Collider other)
        {
            collidedGameobject = other.gameObject;
            entered = true;
            collidedObject = other.name;
        }

        private void OnTriggerExit(Collider other)
        {
            collidedGameobject = other.gameObject;
            exited = true;
            collidedObject = string.Empty;
        }

        private void OnTriggerStay(Collider other)
        {
            collidedGameobject = other.gameObject;
            currentlyTouching = true;
            collidedObject = other.name;
        }
    }
}

