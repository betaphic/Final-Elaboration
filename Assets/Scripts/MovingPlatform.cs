using UnityEngine;

public class MovingPlatform : MonoBehaviour
{
    public Transform pointA;   // Start point of the platform
    public Transform pointB;   // End point of the platform
    public float platformSpeed = 10f;   // Speed of the platform

    private bool movingToB = true;  // Track if the platform is moving towards pointB

    void Update()
    {
        // Move the platform between pointA and pointB
        if (movingToB)
        {
            transform.position = Vector3.MoveTowards(transform.position, pointB.position, platformSpeed * Time.deltaTime);
            if (transform.position == pointB.position)
            {
                movingToB = false; // Reverse direction
            }
        }
        else
        {
            transform.position = Vector3.MoveTowards(transform.position, pointA.position, platformSpeed * Time.deltaTime);
            if (transform.position == pointA.position)
            {
                movingToB = true; // Reverse direction
            }
        }
    }
}
