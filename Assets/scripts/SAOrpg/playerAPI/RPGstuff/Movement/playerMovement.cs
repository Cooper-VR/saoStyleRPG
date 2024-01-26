using SAOrpg.playerAPI.RPGstuff.StatsInventory;
using UnityEngine;
using Valve.VR.InteractionSystem;

namespace SAOrpg.playerAPI.RPGstuff.Movement
{
    public class playerMovement : MonoBehaviour
	{
		#region variables

		public Vector3 velocity;
		public Transform camera;
		private IndexInput indexInput;
		public float speed = 5f;
		public float rotationSpeed = 10f;
		public float deadzone;

		[HideInInspector]
		public CharacterController characterController;

		public Vector3 velocityAddon = Vector3.zero;

		public Vector3 gravityVelocity;
		public Transform groundCheck;
		public float groundDistance = 0.1f;
		public LayerMask groundLayerMask;
		public bool grounded;
		public float jumpHeight = 3f;

		private Vector3 currentRotation;
		private VelocityEstimator velocityEstimator;

		private float xRotation = 0f;


        #endregion

        private void Start()
		{
			//gotta get the compoents
			indexInput = GetComponent<IndexInput>();
			velocityEstimator = GetComponent<VelocityEstimator>();
			characterController = GetComponent<CharacterController>();
		}

		private void Update()
		{


            //set need to set the values from player stats
            speed = GetComponent<playerStats>().skills[0].level;
			velocity = Vector3.zero;
			
			//calling the methods for the controls
			movePlayer();
			rotatePlayer();

			playerJump();

			//use this or else jumping gonna break
			velocity += velocityAddon;

			//extra shit, dont make dashing cry
			characterController.Move(velocity * speed * Time.deltaTime);
		}

		/// <summary>
		/// allows the player to move
		/// </summary>
		private void movePlayer()
		{
			Vector3 move = new Vector3 (indexInput.leftThumbstick.x, 0, indexInput.rightThumbstick.y);
		
			move += new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
			if (move.magnitude > deadzone)
			{
				velocity += camera.TransformVector(move);
			}
			else
			{
				velocity += Vector3.zero;
			}
		}

		/// <summary>
		/// makes the player jump
		/// </summary>
		private void playerJump()
		{
			grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

			if (grounded && gravityVelocity.y < 0)
			{
				gravityVelocity.y = -2f;
			}

			//idk why the hell this is here, it works, who cares
			if ((indexInput.jumpInput.state && grounded) || (Input.GetButton("Jump") && grounded))
			{
				gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * -19.81f);
			}
			gravityVelocity.y += -9.81f * Time.deltaTime;


			velocity += gravityVelocity;
		}

		//valves velocity estrimator sucks

		/// <summary>
		/// get the velocity of the player
		/// </summary>
		/// <returns>vector 3 of the velocity in world space</returns>
		public Vector3 GetVelocity()
		{
			return velocityEstimator.GetVelocityEstimate();
		}
		
		public void rotatePlayer()
		{
			if (GetComponent<DesktopController>().inVR)
			{
                currentRotation += new Vector3(0, indexInput.rightThumbstick.x * rotationSpeed * Time.deltaTime, 0);

                transform.rotation = Quaternion.Euler(currentRotation);

			}
			else
			{

                float mouseX = Input.GetAxis("Mouse X") * 100f * Time.deltaTime;
                float mouseY = Input.GetAxis("Mouse Y") * 100f * Time.deltaTime;

				xRotation -= mouseY;

				camera.transform.localRotation = Quaternion.Euler(xRotation, 0, 0);
				transform.Rotate(Vector3.up * mouseX);
			}
		}

		/// <summary>
		/// get the anglular velocity
		/// </summary>
		/// <returns>get the eular angles of the anglular velocity</returns>
		public Vector3 GetAngularVelocity()
		{
			return velocityEstimator.GetAngularVelocityEstimate();
		}
	}
}

