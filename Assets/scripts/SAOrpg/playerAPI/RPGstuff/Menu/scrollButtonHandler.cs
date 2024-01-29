using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGstuff.Menu
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

            //    buttonAction1();
            }

            if (collisionChecker.entered && collisionChecker.collidedObject.Contains("finger"))
            {
                outerImage.color = alternalColor;
                buttonAction();

            }
            else if (!collisionChecker.entered && collisionChecker.collidedObject.Contains("finger"))
            {
                outerImage.color = initalColor;
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
