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
        // Check if the collided object is tagged as "Cookingspoon"
        if (other.CompareTag("Cookingspoon"))
        {
            string combination = "";

            // Check if each prefab is present in the collider
            if (ContainsPrefabWithTag("CheesePile"))
            {
                Debug.Log("CheesePile detected.");
                combination += "CheesePile_";
            }
            if (ContainsPrefabWithTag("TomatoPile"))
            {
                Debug.Log("TomatoPile detected.");
                combination += "TomatoPile_";
            }
            if (ContainsPrefabWithTag("MushroomPile"))
            {
                Debug.Log("MushroomPile detected.");
                combination += "MushroomPile_";
            }
            if (ContainsPrefabWithTag("Noodlebrick"))
            {
                Debug.Log("Noodlebrick detected.");
                combination += "Noodlebrick_";
            }

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

    // Function to check if a prefab with a specific tag is present in the collider
    bool ContainsPrefabWithTag(string tag)
    {
        Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
        foreach (Collider col in colliders)
        {
            if (col.CompareTag(tag))
                return true;
        }
        return false;
    }
}
