using UnityEngine;
using System.Collections; // Add this line for IEnumerator

public class CapsuleController : MonoBehaviour
{
    public Transform[] positions; // Positions to move the capsule to
    public GameObject dialogueBoxPrefab; // Prefab for DialogueBox
    public GameObject successPrefab; // Prefab for Success
    public GameObject failPrefab; // Prefab for Fail
    public string detectPrefabTag = "CookedNoodles"; // Tag to detect prefabs

    private int currentPositionIndex = 0;
    private bool isMoving = false;

    void Start()
    {
        MoveToNextPosition();
    }

    void Update()
    {
        if (!isMoving && currentPositionIndex < positions.Length)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[currentPositionIndex].position, Time.deltaTime * 2f);
            if (transform.position == positions[currentPositionIndex].position)
            {
                if (currentPositionIndex == 1)
                {
                    SpawnDialogueBox();
                }
                else if (currentPositionIndex == 2)
                {
                    CheckForCookedNoodles();
                }
                currentPositionIndex++;
            }
        }
    }

    void MoveToNextPosition()
    {
        if (currentPositionIndex < positions.Length)
        {
            transform.position = positions[currentPositionIndex].position;
            currentPositionIndex++;
        }
    }

    void SpawnDialogueBox()
    {
        GameObject dialogueBox = Instantiate(dialogueBoxPrefab, transform.position, Quaternion.identity);
        dialogueBox.GetComponent<DialogueBoxController>().capsuleController = this;
    }

    void CheckForCookedNoodles()
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2f);
        bool successTriggered = false;

        foreach (Collider col in colliders)
        {
            if (col.CompareTag(detectPrefabTag))
            {
                if (col.gameObject.name == "Cooked_Noodles_All")
                {
                    Instantiate(successPrefab, transform.position, Quaternion.identity);
                    DestroyBowlPrefabs();
                    successTriggered = true;
                    break;
                }
                else
                {
                    Instantiate(failPrefab, transform.position, Quaternion.identity);
                    StartCoroutine(WaitForSuccess());
                    return;
                }
            }
        }

        if (!successTriggered)
        {
            StartCoroutine(WaitForSuccess());
        }
    }

    void DestroyBowlPrefabs()
    {
        GameObject[] bowls = GameObject.FindGameObjectsWithTag("Bowl");
        foreach (GameObject bowl in bowls)
        {
            Destroy(bowl);
        }
    }

    IEnumerator WaitForSuccess()
    {
        yield return new WaitUntil(() => GameObject.FindWithTag("Success") == null);
        currentPositionIndex--; // Stay at position 2 until success prefab spawns and bowl prefabs are deleted
    }
}
