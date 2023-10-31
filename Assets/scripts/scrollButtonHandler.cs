using SAOrpg.playerAPI;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class scrollButtonHandler : MonoBehaviour
    {
        Color initalColor;
        public Color alternalColor;

        Sprite initalSprite;
        public Sprite alteralSprite;

        private Image outerImage;
        private Image innerImage;
        private collisionChecker collisionChecker;

        private void Start()
        {
            outerImage = GetComponent<Image>();
            innerImage = transform.GetChild(0).GetComponent<Image>();
            collisionChecker = GetComponent<collisionChecker>();

            initalColor = outerImage.color;
            initalSprite = innerImage.sprite;
        }

        private void Update()
        {
            if (collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                outerImage.color = alternalColor;
                innerImage.sprite = alteralSprite;
            }
            else if (!collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                outerImage.color = initalColor;
                innerImage.sprite = initalSprite;
            }

            if (collisionChecker.exited && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                buttonAction();
            }
        }

        private void buttonAction()
        {

        }
    }
}
