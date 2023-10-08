using UnityEngine;
using UnityEngine.InputSystem;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class playerMovement : MonoBehaviour
{
	public Vector3 velocity;
	public Vector3 angularVelocity;
    public Transform camera;
    private IndexInput indexInput;
	public float speed = 5f;
    public float deadzone;

    private CharacterController characterController;


    public Vector3 gravityVelocity;
    public Transform groundCheck;
    public float groundDistance = 0.1f;
    public LayerMask groundLayerMask;
    public bool grounded;
    public float jumpHeight = 3f;
    private VelocityEstimator velocityEstimator;

	private void Start()
	{
        indexInput = GetComponent<IndexInput>();
		velocityEstimator = GetComponent<VelocityEstimator>();
        characterController = GetComponent<CharacterController>();

    }

	private void FixedUpdate()
	{
        

		velocity = GetVelocity();
		angularVelocity = GetAngularVelocity();
        

        movePlayer();
        playerJump();
    }

    private void movePlayer()
    {
        Vector3 move = transform.right * indexInput.leftThumbstick.x + transform.forward * indexInput.leftThumbstick.y;
        if (move.magnitude > deadzone)
        {
            move = camera.InverseTransformVector(move);

            characterController.Move(move * speed * Time.deltaTime);

        }
    }

    private void playerJump()
    {
        grounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundLayerMask);

        if (grounded && gravityVelocity.y < 0)
        {
            gravityVelocity.y = -2f;
        }

        if (indexInput.jumpInput.state && grounded)
        {
            gravityVelocity.y = Mathf.Sqrt(jumpHeight * -2f * -19.81f);
        }

        gravityVelocity.y += -9.81f * Time.deltaTime;

        characterController.Move(gravityVelocity * Time.deltaTime);
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
