using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class bottomHandler : MonoBehaviour
    {
        #region variables

        private collisionChecker collisionChecker;

        public Sprite alternateSprite;
        private Sprite startingSprite;

        private Image imageCom;

        private Sprite currentSprite;

        #endregion

        #region start/update

        private void Start()
        {
            startingSprite = imageCom.sprite;
            collisionChecker = GetComponent<collisionChecker>();
            currentSprite = startingSprite;
        }

        private void Update()
        {
            if (collisionChecker.currentlyTouching)
            {
                currentSprite = alternateSprite;
            }
            else
            {
                currentSprite = startingSprite;
            }

            if (collisionChecker.entered && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                buttonAction();
            }
        }

        #endregion

        private void buttonAction()
        {

        }
    }
}
