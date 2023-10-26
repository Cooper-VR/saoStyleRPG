using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class scrollRectController : MonoBehaviour
    {
        private ScrollRect scroll;
        public Vector2 scrollPos;
        private collisionChecker collisionChecker;
        public Vector3 initalOffset;
        public Vector3 newOffset;

        private void Start()
        {
            scroll = GetComponent<ScrollRect>();
            collisionChecker = GetComponent<collisionChecker>();
            
        }

        private void Update()
        {
            scroll.normalizedPosition = scrollPos;

            //while touching:

            //get vertical offset of finger vs scroll center

            //as the finger moves get a new offset and subtract it from the first one

            //use that new offset as the position;
        }
    }
}
