using UnityEngine;
using UnityEngine.UI;

namespace SAOrpg.playerAPI.RPGstuff.Menu
{
    public class innerButtonHandler : MonoBehaviour
    {
        #region variables
        private collisionChecker collisionChecker;
        private Image image;
        public GameObject logoutPrefab;
        public Color clickColor = Color.white;
        private Color startingColor = Color.white;
        public AudioSource click;
        public bool testBool = false;
        public bool logout = false;
        

        #endregion

        #region start/update

        private void Start()
        {
            click = transform.root.GetChild(0).gameObject.GetComponent<AudioSource>();
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
            
            if (!logout)
            {
                transform.GetChild(0).gameObject.SetActive(true);
            }
            else
            {
                Instantiate(logoutPrefab, transform.position, transform.rotation);
            }
            click.Play();
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
