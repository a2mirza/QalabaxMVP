using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnOnTriggerExit : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private List<GameObject> currentIngredients = new List<GameObject>();
    private float spawnDelay = 3f;
    private BoxCollider coll;

    void Start()
    {
        SpawnPrefab();
        StartCoroutine(CheckAndSpawn());
        coll = GetComponent<BoxCollider>();
        coll.isTrigger = true;

    }

    private void OnTriggerEnter(Collider other)
    {
        // Add ingredient to the list if it's an UncookedIngredient
        if (other.GetComponent<UncookedIngredient>())
        {
            currentIngredients.Add(other.gameObject);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Remove ingredient from the list when it exits
        if (other.GetComponent<UncookedIngredient>())
        {
            currentIngredients.Remove(other.gameObject);
        }
    }

    IEnumerator CheckAndSpawn()
    {
        while (true)
        {
            yield return new WaitForSeconds(spawnDelay); // Wait for the specified delay

            // Check if there are no UncookedIngredients in the trigger area
            if (currentIngredients.Count == 0)
            {
                SpawnPrefab();
            }
        }
    }

    private void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned in the inspector!");
        }
    }
}
