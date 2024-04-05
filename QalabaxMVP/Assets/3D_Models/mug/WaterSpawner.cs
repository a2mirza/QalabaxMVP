using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterSpawner : MonoBehaviour
{
    public GameObject waterPrefab;
    public Transform spawnPoint;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartWater()
    {
        InvokeRepeating("SpawnWater", 0f, 1f);
    }

    public void StopWater()
    {
        CancelInvoke("SpawnWater");
    }

    void SpawnWater()
    {
        Instantiate(waterPrefab, spawnPoint.position, Quaternion.identity);
    }
}
