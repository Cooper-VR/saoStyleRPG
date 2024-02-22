using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace SAOrpg.UI.Buttons
{

	//this should be able to handle all click, inharite this if furture buttons
	public abstract class buttonHandler : MonoBehaviour
	{
		private Animator animator;

		//keep public incase a button uses weird action
		public bool isPressed = false;

	
		public Color pressedColor;
		public Sprite pressedSprite;
		private Sprite defaultSprite;
		private Image image;

		[Header("for item buttons")]
		public bool useColorFallback = true;

        private void Start()
		{
			animator = GetComponent<Animator>();
			image = GetComponent<Image>();

			defaultSprite = image.sprite;
		}

        private void OnTriggerEnter (Collider collision)
		{
            TurnOthersOff();
            //DoActionOn();

        }

        private void OnTriggerExit(Collider collision)
		{
			image.sprite = defaultSprite;
		}

		//for non-togglable buttons so that this can just be called
		public void DoActionOn()
		{
            if (!isPressed)
            {
                //active
                if (pressedSprite == null && useColorFallback)
				{
					image.color = pressedColor;
				}
				else
				{
                    image.sprite = pressedSprite;
                }

				if (animator != null)
				{
					Debug.Log("in the animator part");

					//mainly for item buttons, but can be used wherever
					animator.SetBool("on", true);
				}

				ButtonAction();

				//do stuff here

				isPressed = true;

				return;
			}
            else if (isPressed)
            {
                //make not active
                if (pressedSprite == null && useColorFallback)
				{
					image.color = Color.white;
				}
				else
				{
					image.sprite = defaultSprite;
				}

                if (animator != null)
                {
                    animator.SetBool("on", false);
				}

				PressedAction();
				isPressed = false;
				return;
			}
		}

		
		private void TurnOthersOff()
		{
			for (int i = 0; i < transform.parent.childCount; i++) 
			{
				if(transform.parent.GetChild(i).name != this.name)
				{
					Debug.Log(transform.parent.GetChild(i).name);
					transform.parent.GetChild(i).GetComponent<Animator>().SetBool("on", false);
				}
			}
			DoActionOn();
		}

		//override these, for weird ones like logout or the items
		public abstract void ButtonAction();
		public abstract void PressedAction();
	}
}
