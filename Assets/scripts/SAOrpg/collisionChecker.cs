using UnityEngine;


namespace SAOrpg
{

    //made this cause  unity collision suck dick
    public class collisionChecker : MonoBehaviour
    {
        #region collision states
        public string collidedObject;
        public GameObject collidedGameobject;

        public bool entered;
        public bool exited;
        public bool currentlyTouching;
        public bool TestEnter;

        private float currentTime1;
        private float currentTime2;

        //testing var
        private float aTime;
        #endregion

        private void Update()
        {
            //added this for testing
            //if (TestEnter)
            //{
              //  aTime += Time.deltaTime;
            //}
            //if (aTime >= 0.1f)
            //{
              //  aTime = 0;
                //TestEnter = false;
            //}

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

            if (currentTime1 >= 0.1f)
            {
                //entered = false;
            }

            if (exited)
            {
                currentTime2 += Time.deltaTime;
            }
            if (currentTime2 >= 0.1f)
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
            currentTime1 = 0;
        }

        private void OnTriggerExit(Collider other)
        {
            collidedGameobject = null;
            exited = true;
            collidedObject = string.Empty;
            currentTime2 = 0;

        }

        private void OnTriggerStay(Collider other)
        {
            collidedGameobject = other.gameObject;
            currentlyTouching = true;
            collidedObject = other.name;
        }
    }
}

