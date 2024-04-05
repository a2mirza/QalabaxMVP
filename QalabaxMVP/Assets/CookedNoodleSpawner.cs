using UnityEngine;
using System.Collections.Generic;

public class CookedNoodleSpawner : MonoBehaviour
{
    // Dictionary to map combinations to corresponding prefabs
    Dictionary<string, GameObject> combinationPrefabMap = new Dictionary<string, GameObject>();

    void Start()
    {
        // Populate the combinationPrefabMap with combinations and corresponding prefabs
        combinationPrefabMap.Add("CheesePile_TomatoPile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_All"));
        combinationPrefabMap.Add("CheesePile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Cheese_Mushroom"));
        combinationPrefabMap.Add("TomatoPile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Tomato_Mushroom"));
        combinationPrefabMap.Add("TomatoPile_CheesePile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Cheese_Tomato"));
        combinationPrefabMap.Add("CheesePile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyCheese"));
        combinationPrefabMap.Add("MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyMushroom"));
        combinationPrefabMap.Add("TomatoPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyTomato"));
        combinationPrefabMap.Add("Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyNoodles"));
    }

    void OnTriggerEnter(Collider other)
    {
        // Check if the collided object is one of the prefabs
        if (other.CompareTag("CheesePile") || other.CompareTag("TomatoPile") || other.CompareTag("MushroomPile") || other.CompareTag("Noodlebrick"))
        {
            // Add the collided object's tag to the combination string
            string combination = "";
            combination += other.CompareTag("CheesePile") ? "CheesePile_" : "";
            combination += other.CompareTag("TomatoPile") ? "TomatoPile_" : "";
            combination += other.CompareTag("MushroomPile") ? "MushroomPile_" : "";
            combination += other.CompareTag("Noodlebrick") ? "Noodlebrick_" : "";

            // Remove the trailing underscore
            combination = combination.TrimEnd('_');

            // Check if the combination exists in the map
            if (combinationPrefabMap.ContainsKey(combination))
            {
                // Destroy all objects in the collider
                foreach (Collider col in Physics.OverlapBox(transform.position, transform.localScale / 2))
                {
                    Destroy(col.gameObject);
                }

                // Spawn the corresponding prefab
                Instantiate(combinationPrefabMap[combination], transform.position, Quaternion.identity);
            }
        }
    }
}
