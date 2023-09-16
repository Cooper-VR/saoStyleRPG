using UnityEngine;

public class velocityCalculator : MonoBehaviour
{
    private Vector3 previousPosition; // Previous position of the hand
    public Vector3 velocity; // Current velocity of the hand
    void Start()
    {
        // Initialize the previous position with the current position
        previousPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the current velocity based on position changes
        velocity = (transform.position - previousPosition) / Time.deltaTime;

        // Store the current position as the new previous position
        previousPosition = transform.position;



    }
}
