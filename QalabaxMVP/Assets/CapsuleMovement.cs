using UnityEngine;
using System.Collections; // Add this line to include the System.Collections namespace

public class CapsuleMovement : MonoBehaviour
{
    public Transform startLocation;  // Assign the starting position of the capsule in Unity inspector
    public Transform endLocation;    // Assign the ending position of the capsule in Unity inspector
    public Transform secondaryLocation;  // Assign the secondary position of the capsule in Unity inspector
    public GameObject dialogueBox;  // Assign the dialogue box GameObject in Unity inspector
    public GameObject spritePrefab1; // Sprite for Cooked_Noodles_Cheese_Tomato. Assign in Unity inspector
    public GameObject spritePrefab2; // Sprite for other objects. Assign in Unity inspector
    public string objectToDetect = "Cooked_Noodles_Cheese_Tomato"; // Tag of the object to detect

    private bool reachedEnd = false; // Indicates if the capsule has reached the end location

    void Start()
    {
        // Move the capsule from startLocation to endLocation over 8 seconds
        StartCoroutine(MoveCapsule(startLocation.position, endLocation.position, 8f));
    }

    IEnumerator MoveCapsule(Vector3 startPos, Vector3 endPos, float duration)
    {
        float startTime = Time.time;

        while (Time.time - startTime < duration)
        {
            float t = (Time.time - startTime) / duration;
            transform.position = Vector3.Lerp(startPos, endPos, t);
            yield return null;
        }

        transform.position = endPos;
        reachedEnd = true;
        SpawnSpriteAtDialogueBox(); // When the capsule reaches the end location, spawn a sprite at the dialogue box
    }

    void OnTriggerEnter(Collider other)
    {
        if (reachedEnd)
        {
            if (other.CompareTag("Bowl")) // If the collided object is a bowl, do nothing
            {
                return;
            }

            if (other.CompareTag(objectToDetect)) // If the collided object has the tag specified in objectToDetect
            {
                SpawnSpriteAtSecondaryLocation(spritePrefab1); // Spawn spritePrefab1 at the secondary location
            }
            else
            {
                SpawnSpriteAtDialogueBox(spritePrefab2); // Otherwise, spawn spritePrefab2 at the dialogue box
            }
        }
    }

    void SpawnSpriteAtDialogueBox(GameObject spritePrefab = null)
    {
        if (dialogueBox != null && spritePrefab != null)
        {
            Instantiate(spritePrefab, dialogueBox.transform); // Spawn the spritePrefab as a child of the dialogue box
        }
    }

    void SpawnSpriteAtSecondaryLocation(GameObject spritePrefab)
    {
        if (spritePrefab != null)
        {
            Instantiate(spritePrefab, secondaryLocation.position, Quaternion.identity); // Spawn the spritePrefab at the secondary location
        }
    }
}
