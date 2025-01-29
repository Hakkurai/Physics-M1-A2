using UnityEngine;

public class CannonController : MonoBehaviour
{
    public float rotationSpeed = 100f; // Speed of rotation

    void Update()
    {
        // Get the horizontal input (-1 for "A"/Left Arrow, +1 for "D"/Right Arrow)
        float horizontalInput = Input.GetAxis("Horizontal");

        // Rotate the cannon based on horizontal input
        if (horizontalInput != 0)
        {
            transform.Rotate(-Vector3.right, horizontalInput * rotationSpeed * Time.deltaTime);
            Debug.Log($"Rotating {(horizontalInput < 0 ? "left" : "right")}");
        }
    }
}
