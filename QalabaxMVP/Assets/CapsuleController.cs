using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class CapsuleController : MonoBehaviour
{
    public Transform[] positions;
    public Image dialogueBoxImage;
    public Sprite[] orderSprites;
    public GameObject successPrefab;
    public GameObject failPrefab;
    public float waitTime;
    public float rotationSpeed = 5f; // Rotation speed for the character

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

    private void Start()
    {
        StartCoroutine(MoveSequence());
        UpdateOrderSprite();
    }

    IEnumerator MoveSequence()
    {
        yield return MoveToPosition(0);

        yield return MoveToPosition(1);
        StartCoroutine(StartWaiting());
        yield return new WaitUntil(() => !isWaiting);

        yield return MoveToPosition(2);
    }

    IEnumerator MoveToPosition(int positionIndex)
    {
        isMoving = true;
        while (Vector3.Distance(transform.position, positions[positionIndex].position) > 0.01f)
        {
            // Move towards the target position
            transform.position = Vector3.MoveTowards(transform.position, positions[positionIndex].position, Time.deltaTime * 2f);

            // Rotate towards the target rotation
            Quaternion targetRotation = Quaternion.LookRotation(positions[positionIndex].position - transform.position);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

            yield return null;
        }
        isMoving = false;
    }

    IEnumerator StartWaiting()
    {
        float timer = 0;
        isWaiting = true;
        while (isWaiting && timer < waitTime)
        {
            timer += Time.deltaTime;
            yield return null;
        }
        isWaiting = false;
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
