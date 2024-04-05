using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.Events;

public class TomatoSlicing : MonoBehaviour
{
    public GameObject Tomato_sliced_pile; // Reference to the tomato slice prefab

    private XRGrabInteractable grabInteractable; // Reference to the XRGrabInteractable component

    void Start()
    {
        // Get the XRGrabInteractable component attached to this GameObject
        grabInteractable = GetComponent<XRGrabInteractable>();

        if (grabInteractable != null)
        {
            // Subscribe to the selectEntered event to detect when the knife is grabbed
            grabInteractable.selectEntered.AddListener(OnGrabbed);
        }
        else
        {
            Debug.LogError("XRGrabInteractable component not found!");
        }
    }

    void OnCollisionEnter(Collision collision)
    {
        // Check if the collision is with the knife
        if (collision.collider.CompareTag("Knife"))
        {
            // Perform the slicing action
            SliceTomato(collision.contacts[0].point);
        }
    }

    void SliceTomato(Vector3 contactPoint)
    {
        // Instantiate a tomato slice at the contact point
        Instantiate(Tomato_sliced_pile, contactPoint, Quaternion.identity);

        // Disable the tomato GameObject
        gameObject.SetActive(false);
    }

    void OnGrabbed(SelectEnterEventArgs args)
    {
        // Enable collision detection for the tomato when the knife is grabbed
        GetComponent<Collider>().enabled = true;
    }
}
