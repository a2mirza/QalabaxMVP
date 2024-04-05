using UnityEngine;

public class SpawnOnTriggerExit : MonoBehaviour
{
    public GameObject prefabToSpawn;
    private bool initialSpawned = false;

    void Start()
    {
        SpawnPrefab();
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("SpawnTrigger") && initialSpawned)
        {
            SpawnPrefab();
        }
    }

    public void SpawnPrefab()
    {
        if (prefabToSpawn != null)
        {
            Instantiate(prefabToSpawn, transform.position, transform.rotation);
            initialSpawned = true;
        }
        else
        {
            Debug.LogError("Prefab to spawn is not assigned in the inspector!");
        }
    }
}
