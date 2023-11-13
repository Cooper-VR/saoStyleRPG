using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class bottomHandler : MonoBehaviour
    {
        #region variables

        public Sprite alternateSprite;
        public int menuIndex;

        public AudioSource click;

        private collisionChecker collisionChecker;
        private Animator menuController;
        private Sprite startingSprite;
        private Image imageCom;
        private Sprite currentSprite;

        #endregion

        #region start/update

        private void Start()
        {
            click = transform.root.GetChild(0).gameObject.GetComponent<AudioSource>();

            imageCom = GetComponent<Image>();
            menuController = transform.parent.parent.GetComponent<Animator>();
            startingSprite = imageCom.sprite;
            collisionChecker = GetComponent<collisionChecker>();
            currentSprite = startingSprite;
        }

        private void Update()
        {
            imageCom.sprite = currentSprite;
            if (collisionChecker.currentlyTouching && (collisionChecker.collidedObject == "Controller (left)" || collisionChecker.collidedObject == "rightFinger"))
            {
                currentSprite = alternateSprite;
            }
            else
            {
                currentSprite = startingSprite;
            }

            if (collisionChecker.entered && (collisionChecker.collidedObject == "Controller (left)" || collisionChecker.collidedObject == "rightFinger"))
            {
                buttonAction();
            } 
        }

        #endregion

        private void buttonAction()
        {
            menuController.SetInteger("firstLayer", menuIndex);
            click.Play();
        }
    }
}
