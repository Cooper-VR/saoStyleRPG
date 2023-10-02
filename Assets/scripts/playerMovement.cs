using UnityEngine;
using Valve.VR;
using Valve.VR.InteractionSystem;

public class playerMovement : MonoBehaviour
{
	public Vector3 velocity;
	public Vector3 angularVelocity;

    public Vector3 moveVector;

	public float speed = 5f;

    private CharacterController characterController;

    //steam right hand input
    public SteamVR_Action_Vector2 RightThumbstickAction = null;
    public SteamVR_Action_Vector2 RightTrackpadAction = null;
    public SteamVR_Action_Single RightSqueezeAction = null;
    public SteamVR_Action_Boolean RightGripAction = null;
    public SteamVR_Action_Boolean RightPinchAction = null;
    public SteamVR_Action_Skeleton RightSkeletonAction = null;

    //steam left hand input
    public SteamVR_Action_Vector2 LeftThumbstickAction = null;
    public SteamVR_Action_Vector2 LeftTrackpadAction = null;
    public SteamVR_Action_Single LeftSqueezeAction = null;
    public SteamVR_Action_Boolean LeftGripAction = null;
    public SteamVR_Action_Boolean LeftPinchAction = null;
    public SteamVR_Action_Skeleton LeftSkeletonAction = null;

    // right hand input as normal variables
    private Vector2 rightThumbstick;
    private Vector2 rightTrackpad;
    private float rightSqueeze;
    private bool rightGrip;
    private bool RightPinch;
    public float[] rightFinger = new float[5];

    //left hand input as normal variables
    private Vector2 leftThumbstick;
    private Vector2 leftTrackpad;
    private float leftSqueeze;
    private bool leftGrip;
    private bool leftPinch;
    public float[] leftFinger = new float[5];

    private VelocityEstimator velocityEstimator;

	private void Start()
	{
		velocityEstimator = GetComponent<VelocityEstimator>();
        characterController = GetComponent<CharacterController>();

    }

	private void FixedUpdate()
	{
		velocity = GetVelocity();
		angularVelocity = GetAngularVelocity();
        RightThumbstick();
        RightTrackpad();
        RightSqueeze();
        RightGrip();
        rightPinch();
        RightFingers();
        LeftThumbstick();
        LeftTrackpad();
        LeftSqueeze();
        LeftGrip();
        LeftPinch();
        LeftFingers();

        moveVector.x = leftTrackpad.x;
        moveVector.y = leftTrackpad.y;
    }

    private void movePlayer()
    {
        if (leftTrackpad.magnitude != 0f)
        {
            characterController.Move(moveVector);
        }
        
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

    // right and left hand input detection
    public void RightThumbstick()
    {
        if (RightThumbstickAction.axis == Vector2.zero)
        {
            return;
        }
        rightThumbstick = RightThumbstickAction.axis;
    }
    public void RightTrackpad()
    {
        if (RightTrackpadAction.axis == Vector2.zero)
        {
            return;
        }
        rightTrackpad = RightTrackpadAction.axis;
    }
    public void RightSqueeze()
    {
        if (RightSqueezeAction.axis == 0.0f)
        {
            return;
        }
        rightSqueeze = RightSqueezeAction.axis;
    }
    public void RightGrip()
    {
        if (RightGripAction.stateDown)
        {
            rightGrip = true;
        }
        if (RightGripAction.stateUp)
        {
            rightGrip = false;
        }
    }
    public void rightPinch()
    {
        if (RightPinchAction.stateDown)
        {
            RightPinch = false;
        }
        if (RightPinchAction.stateUp)
        {
            RightPinch = false;
        }
    }
    public void RightFingers()
    {
        if (RightSkeletonAction.indexCurl != 0.0f)
        {
            rightFinger[0] = RightSkeletonAction.indexCurl;
        }
        if (RightSkeletonAction.middleCurl != 0.0f)
        {
            rightFinger[1] = RightSkeletonAction.middleCurl;
        }
        if (RightSkeletonAction.ringCurl != 0.0f)
        {
            rightFinger[2] = RightSkeletonAction.ringCurl;
        }
        if (RightSkeletonAction.pinkyCurl != 0.0f)
        {
            rightFinger[3] = RightSkeletonAction.pinkyCurl;
        }
        if (RightSkeletonAction.thumbCurl != 0.0f)
        {
            rightFinger[4] = RightSkeletonAction.thumbCurl;
        }
    }
    public void LeftThumbstick()
    {
        if (LeftThumbstickAction.axis == Vector2.zero)
        {
            return;
        }
        leftThumbstick = LeftThumbstickAction.axis;
    }
    public void LeftTrackpad()
    {
        if (LeftTrackpadAction.axis == Vector2.zero)
        {
            return;
        }
        leftTrackpad = LeftTrackpadAction.axis;
    }
    public void LeftSqueeze()
    {
        if (LeftSqueezeAction.axis == 0.0f)
        {
            return;
        }
        leftSqueeze = LeftSqueezeAction.axis;
    }
    public void LeftGrip()
    {
        if (LeftGripAction.stateDown)
        {
            leftGrip = true;
        }
        if (LeftGripAction.stateUp)
        {
            leftGrip = false;
        }
    }
    public void LeftPinch()
    {
        if (LeftPinchAction.stateDown)
        {
            leftPinch = true;
        }
        if (LeftPinchAction.stateUp)
        {
            leftPinch = false;
        }
    }
    public void LeftFingers()
    {
        if (LeftSkeletonAction.indexCurl != 0.0f)
        {
            leftFinger[0] = LeftSkeletonAction.indexCurl;
        }
        if (LeftSkeletonAction.middleCurl != 0.0f)
        {
            leftFinger[1] = LeftSkeletonAction.middleCurl;
        }
        if (LeftSkeletonAction.ringCurl != 0.0f)
        {
            leftFinger[2] = LeftSkeletonAction.ringCurl;
        }
        if (LeftSkeletonAction.pinkyCurl != 0.0f)
        {
            leftFinger[3] = LeftSkeletonAction.pinkyCurl;
        }
        if (LeftSkeletonAction.thumbCurl != 0.0f)
        {
            leftFinger[4] = LeftSkeletonAction.thumbCurl;
        }
    }
}
