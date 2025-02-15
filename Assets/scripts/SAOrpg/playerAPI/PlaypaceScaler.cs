using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace SAOrpg.playerAPI
{
    public class PlaypaceScaler : MonoBehaviour
    {
        public float playerHeight = 2.5f;
        public float height = 1.73f;

        private void Update()
        {
            float scaleFactor = height / playerHeight;

            transform.localScale = new Vector3(scaleFactor, scaleFactor, scaleFactor);
        }
    }
}

