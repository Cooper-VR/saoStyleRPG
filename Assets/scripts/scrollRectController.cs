using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class scrollRectController : MonoBehaviour
    {
        private ScrollRect scroll;
        public Vector2 scrollPos;
        private collisionChecker collisionChecker;
        public Vector3 initalOffset;
        public Vector3 newOffset;

        private GameObject currentHand;

        private void Start()
        {
            scroll = GetComponent<ScrollRect>();
            collisionChecker = GetComponent<collisionChecker>();
            
        }

        private void Update()
        {
            transform.GetChild(0).transform.localPosition = scrollPos;

            //while touching:
            if (collisionChecker.entered && collisionChecker.collidedObject.Contains("Controller"))
            {
                currentHand = GameObject.Find(collisionChecker.collidedObject);
                initalOffset = currentHand.transform.position - transform.position;
            }

            if (collisionChecker.currentlyTouching && collisionChecker.collidedObject.Contains("Controller"))
            {
                currentHand = GameObject.Find(collisionChecker.collidedObject);
                newOffset = (currentHand.transform.position - transform.position) - initalOffset;
            }

            //get vertical offset of finger vs scroll center

            scrollPos.y = newOffset.y;
            //as the finger moves get a new offset and subtract it from the first one

            //use that new offset as the position;
        }
    }
}
