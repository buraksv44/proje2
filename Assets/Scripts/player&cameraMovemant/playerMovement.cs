using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public Collider platformCollider;
    private float minX, maxX, minZ, maxZ;
    public GameObject orientation;

    private void Start()
    {
        // Calculate the boundaries based on the platform's collider
        minX = platformCollider.bounds.min.x;
        maxX = platformCollider.bounds.max.x;
        minZ = platformCollider.bounds.min.z;
        maxZ = platformCollider.bounds.max.z;
    }

    private void Update()
    {
        // Get the movement input from the player
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Get the forward direction
        Vector3 forwardDirection = orientation.transform.forward;

        // Calculate the movement vector based on the input and orientation
        Vector3 movementVector = (forwardDirection * verticalInput + orientation.transform.right * horizontalInput) * moveSpeed * Time.deltaTime;

        // Calculate the new position based on the movement vector
        Vector3 newPosition = transform.position + movementVector;

        // Clamp the new position within the boundaries
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.z = Mathf.Clamp(newPosition.z, minZ, maxZ);

        // Apply the new position to the player
        transform.position = newPosition;
    }
}
