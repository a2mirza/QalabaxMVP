using UnityEngine;
using System; // Add this line to import the System namespace

public class UIButtonController : MonoBehaviour
{
    // Reference to the empty GameObject with a collider
    public GameObject colliderObject;

    // Tags to be deleted
    private string[] tagsToDelete = {
        "Noodles",
        "NoodlesCheese",
        "NoodlesMushroom",
        "NoodlesTomato",
        "NoodlesTomatoMushroom",
        "NoodlesTomatoCheese",
        "NoodlesMushroomCheese",
        "NoodlesAll",
        "CheesePile",
        "TomatoPile",
        "Noodlebrick",
        "MushroomPile"
    };

    // Method to be called when the UI button is pressed
    public void OnUIButtonPressed()
    {
        // Ensure colliderObject is not null
        if (colliderObject == null)
        {
            Debug.LogError("ColliderObject is not assigned.");
            return;
        }

        // Get colliders within the colliderObject's bounds
        Collider[] colliders = Physics.OverlapBox(colliderObject.transform.position, colliderObject.transform.localScale / 2);

        // Iterate through colliders
        foreach (Collider col in colliders)
        {
            // Check if the collider's tag is in the tagsToDelete array
            if (Array.Exists(tagsToDelete, tag => tag == col.tag))
            {
                // Destroy the object
                Destroy(col.gameObject);
            }
        }
    }
}
