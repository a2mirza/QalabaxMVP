using UnityEngine;

public class BowlColliderHandler : MonoBehaviour
{
    // Reference to the empty child object of the Bowl prefab
    public Transform emptyChild;
    private bool isCooked;

    public orderBowl currentBowl;
    public enum orderBowl
    {
        Noodles,
        NoodlesCheese,
        NoodlesMushroom,
        NoodlesTomato,
        NoodlesTomatoMushroom,
        NoodlesTomatoCheese,
        NoodlesMushroomCheese,
        NoodlesAll
    }

    private void Start()
    {
        isCooked = false;
    }

    // This method is called whenever a trigger collider enters another trigger collider
    private void OnTriggerEnter(Collider other)
    {
        // Check if the collider that entered is a cooked noodles pot object
        if (other.CompareTag("Noodles") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.Noodles; //change this to make this 
        }
        else if (other.CompareTag("NoodlesCheese") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
        else if (other.CompareTag("NoodlesMushroom") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
        else if (other.CompareTag("NoodlesTomato") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
        else if (other.CompareTag("NoodlesTomatoMushroom") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
        else if (other.CompareTag("NoodlesMushroomCheese") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
        else if (other.CompareTag("NoodlesAll") && !isCooked) //Make New tags for each prefab
        {
            // Get the prefab of the pot object
            GameObject potPrefab = other.gameObject;

            // Clone the prefab and position it on the empty child object of the Bowl
            GameObject clonedPrefab = Instantiate(potPrefab, emptyChild.position, emptyChild.rotation, emptyChild);

            // Alter the dimension of the cloned prefab as needed
            // For example, you can change the scale of the cloned prefab
            clonedPrefab.transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
            isCooked = true;
            currentBowl = orderBowl.NoodlesCheese; //change this to make this 
        }
    }
}

