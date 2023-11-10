using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class innerButtonHandler : MonoBehaviour
    {
        #region variables

        public int menuIndex;

        private collisionChecker collisionChecker;
        private Animator menuController;
        private Image imageCom;

        public Color alternateColor;
        private Color startingColor;
        private Color currentColor;

        public Sprite innerAlternateSprite;
        private Sprite innerStartingSprite;
        private Image innerImageCom;
        private Sprite innerCurrentSprite;

        #endregion

        #region start/update

        private void Start()
        {
            menuController = transform.parent.parent.GetComponent<Animator>();
            collisionChecker = GetComponent<collisionChecker>();

            imageCom = GetComponent<Image>();
            startingColor = imageCom.color;
            currentColor = startingColor;

            innerImageCom = transform.GetChild(1).GetComponent<Image>();
            innerStartingSprite = innerImageCom.sprite;
            innerCurrentSprite = innerStartingSprite;
        }

        private void Update()
        {
            imageCom.color = currentColor;
            if (collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "Controller (left)" || collisionChecker.collidedObject == "rightFinger"))
            {
                currentColor = alternateColor;
                innerCurrentSprite = innerAlternateSprite;
            }
            else if (!collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "Controller (left)" || collisionChecker.collidedObject == "rightFinger"))
            {
                currentColor = startingColor;
                innerCurrentSprite = innerStartingSprite;
            }

            if (collisionChecker.exited && (collisionChecker.collidedObject == "Controller (left)" || collisionChecker.collidedObject == "rightFinger"))
            {
                buttonAction();
            }
        }

        #endregion

        private void buttonAction()
        {
            innerButtonHandler[] gameObjects = transform.parent.GetComponentsInChildren<innerButtonHandler>();
            for (int i = 0; i < gameObjects.Length; i++)
            {
                gameObjects[i].transform.GetChild(0).gameObject.SetActive(false);
            }

            transform.GetChild(0).gameObject.SetActive(true);
        }
    }
}
