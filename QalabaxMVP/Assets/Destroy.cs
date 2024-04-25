using UnityEngine;

public class DestroyObjectsWithTag : MonoBehaviour
{
    // Function called when a collision is detected
    private void OnCollisionEnter(Collision collision)
    {
        // Check if the collided object has the tag "Bowl"
        if (collision.gameObject.CompareTag("Bowl"))
        {
            // Destroy the collided object
            Destroy(collision.gameObject);
        }
    }
}
