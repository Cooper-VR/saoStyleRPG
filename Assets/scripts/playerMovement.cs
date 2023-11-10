using SAOrpg.playerAPI.RPGsstuff.stats;
using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;
using Valve.VR.InteractionSystem;

namespace SAOrpg.playerAPI
{
    public class playerMovement : MonoBehaviour
    {
        #region variables

        public Vector3 velocity;
        public Transform camera;
        private IndexInput indexInput;
        public float speed = 5f;
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
        private VelocityEstimator velocityEstimator;
        

        #endregion

        private void Start()
        {
            indexInput = GetComponent<IndexInput>();
            velocityEstimator = GetComponent<VelocityEstimator>();
            characterController = GetComponent<CharacterController>();
            

        }

        private void Update()
        {
            speed = GetComponent<playerStats>().skills[0].level;
            velocity = Vector3.zero;
            movePlayer();
            playerJump();

            velocity += velocityAddon;

            characterController.Move(velocity * speed * Time.deltaTime);
        }

        /// <summary>
        /// allows the player to move
        /// </summary>
        private void movePlayer()
        {
            Vector3 move = new Vector3 (indexInput.leftThumbstick.x, 0, indexInput.rightThumbstick.y);
            //Vector3 move = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));
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

            if ((indexInput.jumpInput.state && grounded) || (Input.GetButton("Jump") && grounded))
            {
                gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * -19.81f);
            }

            gravityVelocity.y += -9.81f * Time.deltaTime;

            velocity += gravityVelocity;
        }

        /// <summary>
        /// get the velocity of the player
        /// </summary>
        /// <returns>vector 3 of the velocity in world space</returns>
        public Vector3 GetVelocity()
        {
            return velocityEstimator.GetVelocityEstimate();
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

