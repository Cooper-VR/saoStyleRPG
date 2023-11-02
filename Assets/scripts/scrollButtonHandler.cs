using SAOrpg.playerAPI;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class scrollButtonHandler : MonoBehaviour
    {
        Color initalColor;
        public Color alternalColor;

        private Image outerImage;

        private collisionChecker collisionChecker;

        public RectTransform removeButton;
        public RectTransform spawnButton;

        public bool testBool;

        private void Start()
        {
            outerImage = GetComponent<Image>();
            collisionChecker = GetComponent<collisionChecker>();

            initalColor = outerImage.color;
        }

        private void Update()
        {
            if (testBool)
            {

                buttonAction();
            }
            if (!testBool)
            {

                buttonAction1();
            }

            if (collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                outerImage.color = alternalColor;
            }
            else if (!collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                outerImage.color = initalColor;
            }

            if (collisionChecker.exited && (collisionChecker.collidedObject == "leftFinger" || collisionChecker.collidedObject == "rightFinger"))
            {
                buttonAction();
            }
        }

        private void buttonAction()
        {
            gameObject.GetComponent<Animator>().SetBool("on", true);
        }
        private void buttonAction1()
        {
            gameObject.GetComponent<Animator>().SetBool("on", false);
        }
    }
}
