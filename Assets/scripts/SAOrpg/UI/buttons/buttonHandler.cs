using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.UI;

namespace SAOrpg.UI.Buttons
{
	public abstract class buttonHandler : MonoBehaviour
	{
		private Animator animator;
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

		public abstract void ButtonAction();
		public abstract void PressedAction();
	}
}
