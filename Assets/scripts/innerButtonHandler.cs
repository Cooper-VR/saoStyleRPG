using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGsstuff.Menu
{
    public class innerButtonHandler : MonoBehaviour
    {
        #region variables
        private collisionChecker collisionChecker;
        private Image image;

        public Color clickColor = Color.white;
        private Color startingColor = Color.white;

        public bool testBool = false;
        

        #endregion

        #region start/update

        private void Start()
        {
            collisionChecker = GetComponent<collisionChecker>();
            image = GetComponent<Image>();
            startingColor = image.color;
        }

        private void Update()
        {
            if (collisionChecker.currentlyTouching)
            {
                image.color = clickColor;

            }
            if (collisionChecker.exited || testBool)
            {
                image.color = startingColor;

                testBool = false;

                turnButtonsOff();
                buttonAction();
            }
        }

        #endregion

        private void buttonAction()
        {
            transform.GetChild(0).gameObject.SetActive(true);
        }
        private void turnButtonsOff()
        {
            for (int i = 0; i < transform.parent.childCount; i++)
            {
                if (transform.parent.GetChild(i) != transform)
                {
                    transform.parent.GetChild(i).GetChild(0).gameObject.SetActive(false);
                }
            }
        }
    }
}
