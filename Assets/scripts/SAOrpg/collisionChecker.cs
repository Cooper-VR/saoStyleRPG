using UnityEngine;


namespace SAOrpg
{

    //made this cause  unity collision suck dick. basically i can get collision data from external classes with this
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
            if (entered)
            {
                currentTime1 += Time.deltaTime;
            }
            if (currentTime1 >= Time.deltaTime * 1.1)
            {
                entered = false;
                currentTime1 = 0f;
            }

            if (exited)
            {
                currentTime2 += Time.deltaTime;
            }
            if (currentTime2 >= Time.deltaTime * 1.1f)
            {
                exited = false;
                currentTime2 = 0f;
            }

            if (!currentlyTouching)
            {
                collidedObject = null;
                collidedGameobject = null;
            }
        }

        //set the state values to the state of the collider
        private void OnTriggerEnter(Collider other)
        {
            entered = true;
            collidedGameobject = other.gameObject;
            collidedObject = other.gameObject.name;
        }

        private void OnTriggerExit(Collider other)
        {
            currentlyTouching = false;

        }

        private void OnTriggerStay(Collider other)
        {
            currentlyTouching = true;
            collidedGameobject = other.gameObject;
            collidedObject = other.gameObject.name;
        }
    }
}

