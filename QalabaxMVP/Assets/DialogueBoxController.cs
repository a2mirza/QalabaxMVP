using UnityEngine;

public class DialogueBoxController : MonoBehaviour
{
    public CapsuleController capsuleController;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("VRController"))
        {
            // Assuming "A button" is mapped to Fire1
            if (Input.GetButtonDown("Fire1"))
            {
                Destroy(gameObject); // Destroy the dialogue box upon interaction
            }
        }
    }
}
