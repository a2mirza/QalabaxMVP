using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Add this line for IEnumerator

public class CapsuleController : MonoBehaviour
{
    public Transform[] positions; // Positions to move the capsule to
    public Image dialogueBoxImage; // UI Image to display the order
    public Sprite[] orderSprites; // Array of sprites corresponding to different orders
    public GameObject successPrefab; // Prefab for showing success
    public GameObject failPrefab; // Prefab for showing failure

    public requiredOrderTag currentOrder;
    public enum requiredOrderTag
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

        

    private int currentPositionIndex = 0;
    private bool isWaiting = false;
    private bool isMoving = false;
    public float waitTime;

    private void Start()
    {
        StartCoroutine(MoveSequence());
        UpdateOrderSprite();
    }

    IEnumerator MoveSequence()
    {
        // Move to position 0 initially
        yield return MoveToPosition(0);

        // Wait at position 1 until an order is received or timer expires
        yield return MoveToPosition(1);
        StartCoroutine(StartWaiting());
        yield return new WaitUntil(() => !isWaiting); // Wait for the specified time at position 1

        

        // Then move to position 2
        yield return MoveToPosition(2);
    }

    IEnumerator MoveToPosition(int positionIndex)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, positions[positionIndex].position) > 0.01f)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[positionIndex].position, Time.deltaTime * 2f);
            yield return null; // Wait a frame and then continue
        }
        isMoving = false;
    }

    IEnumerator StartWaiting()
    {
        float timer = 0; // Reset timer
        isWaiting = true; // Start waiting
        while (isWaiting && timer < waitTime)
        {
            timer += Time.deltaTime; // Increment the timer by the time of the last frame
            yield return null; // Wait until the next frame
        }
        isWaiting = false; // Stop waiting if the timer reaches the wait time

    }

    

    private void OnTriggerEnter(Collider other)
    {
       if (other.gameObject.CompareTag("Bowl"))
        {
            BowlColliderHandler bowl = other.GetComponent<BowlColliderHandler>();
            if (bowl.currentBowl.ToString() == currentOrder.ToString())
            {
                successPrefab.SetActive(true);
                isWaiting = false;
            }
            else
            {
                failPrefab.SetActive(true); 
                isWaiting = false;
            }
        }
    }

    public void UpdateOrderSprite()
    {
        // Check the current order and update the sprite accordingly
        switch (currentOrder)
        {
            case requiredOrderTag.Noodles:
                dialogueBoxImage.sprite = orderSprites[0];
                break;
            case requiredOrderTag.NoodlesCheese:
                dialogueBoxImage.sprite = orderSprites[1];
                break;
            case requiredOrderTag.NoodlesMushroom:
                dialogueBoxImage.sprite = orderSprites[2];
                break;
            case requiredOrderTag.NoodlesTomato:
                dialogueBoxImage.sprite = orderSprites[3];
                break;
            case requiredOrderTag.NoodlesTomatoMushroom:
                dialogueBoxImage.sprite = orderSprites[4];
                break;
            case requiredOrderTag.NoodlesTomatoCheese:
                dialogueBoxImage.sprite = orderSprites[5];
                break;
            case requiredOrderTag.NoodlesMushroomCheese:
                dialogueBoxImage.sprite = orderSprites[6];
                break;
            case requiredOrderTag.NoodlesAll:
                dialogueBoxImage.sprite = orderSprites[7];
                break;
            default:
                Debug.LogError("Unknown order tag!");
                break;
        }
    }
}


    
    
