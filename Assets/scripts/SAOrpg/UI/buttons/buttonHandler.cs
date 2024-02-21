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

		private void Start()
		{
			animator = GetComponent<Animator>();
			image = GetComponent<Image>();

			defaultSprite = image.sprite;
		}

		private void OnCollisionEnter(Collision collision)
		{
			DoAction();
		}

		private void OnCollisionExit(Collision collision)
		{
			image.sprite = defaultSprite;
		}

		//for non-togglable buttons so that this can just be called
		public void DoAction()
		{
            if (!isPressed)
            {
                //active
                if (pressedSprite == null)
				{
					image.color = pressedColor;
				}
				else
				{
                    image.sprite = pressedSprite;
                }

				if (animator != null)
				{
					//mainly for item buttons, but can be used wherever
					animator.SetBool("ToggleOn", true);
				}

				ButtonAction();

				//do stuff here

				isPressed = true;
			}
			if (isPressed)
			{
				//make not active
				if (pressedSprite == null)
				{
					image.color = Color.white;
				}
				else
				{
					image.sprite = defaultSprite;
				}

                if (animator != null)
                {
                    animator.SetBool("ToggleOn", false);
				}


				PressedAction();
				isPressed = false;
			}

		}

		//override these, for weird ones like logout or the items
		public abstract void ButtonAction();
		public abstract void PressedAction();
	}
}
