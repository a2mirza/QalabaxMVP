using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class CookedNoodleSpawner : MonoBehaviour
{
    // Dictionary to map combinations to corresponding prefabs
    //Dictionary<string, GameObject> combinationPrefabMap = new Dictionary<string, GameObject>();

    [System.Serializable]
    public struct Recipe
    {
        public List<CookedIngredients.ingredientType> ingredientTypes;
        public GameObject prefab;
    }

    // Create a list of recipes
    public List<Recipe> recipes;
    [Header ("DO NOT EDIT/ ONLY FOR CHECKING INGREDIENTS")]
    public List<CookedIngredients.ingredientType> ingredients;


   // string combination;

    void Start()
    {
        //// Populate the combinationPrefabMap with combinations and corresponding prefabs
        //combinationPrefabMap.Add("CheesePile_TomatoPile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_All"));
        //combinationPrefabMap.Add("CheesePile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Cheese_Mushroom"));
        //combinationPrefabMap.Add("TomatoPile_MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Tomato_Mushroom"));
        //combinationPrefabMap.Add("TomatoPile_CheesePile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_Cheese_Tomato"));
        //combinationPrefabMap.Add("CheesePile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyCheese"));
        //combinationPrefabMap.Add("MushroomPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyMushroom"));
        //combinationPrefabMap.Add("TomatoPile_Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyTomato"));
        //combinationPrefabMap.Add("Noodlebrick", Resources.Load<GameObject>("Cooked_Noodles_OnlyNoodles"));
        //combination = "";

        ingredients = new List<CookedIngredients.ingredientType>();
    }

    void OnTriggerEnter(Collider other)
    {
        CookedIngredients cookedIngredient = other.GetComponent
            <CookedIngredients>();
        // Check if the collided object has CookedIngredients Components
        if (cookedIngredient != null)
        {

            var ingredientType = cookedIngredient.ing;

            // Check if each prefab is present in the collider
            if (ingredientType == CookedIngredients.ingredientType.cheese && !ingredients.Contains(ingredientType))
            {
                Debug.Log("CheesePile detected.");
                //combination += "CheesePile_";
                //Debug.Log(combination);
                ingredients.Add(ingredientType);
                cookedIngredient.xRGrabInteractable.enabled = false;

            }
            else if (ingredientType == CookedIngredients.ingredientType.tomato && !ingredients.Contains(ingredientType))
            {
                Debug.Log("TomatoPile detected.");
                //combination += "TomatoPile_";
                //Debug.Log(combination);
                ingredients.Add(ingredientType);
                cookedIngredient.xRGrabInteractable.enabled = false;
            }
            else if (ingredientType == CookedIngredients.ingredientType.mushroom && !ingredients.Contains(ingredientType))
            {
                Debug.Log("MushroomPile detected.");
                //combination += "MushroomPile_";
                //Debug.Log(combination);
                ingredients.Add(ingredientType);
                cookedIngredient.xRGrabInteractable.enabled = false;
            }
            else if (ingredientType == CookedIngredients.ingredientType.noodle && !ingredients.Contains(ingredientType))
            {
                Debug.Log("Noodlebrick detected.");
                //combination += "Noodlebrick_";
                //Debug.Log(combination);
                ingredients.Add(ingredientType);
                cookedIngredient.xRGrabInteractable.enabled = false;
            }

        }

        if (other.gameObject.CompareTag("Cookingspoon"))
        {
            Debug.Log("Spoon Touched");
            if (ingredients != null)
            {
                ConfirmCombo();
            }
            
        }
    }

    //// Function to check if a prefab with a specific tag is present in the collider
    //bool ContainsPrefabWithTag(string tag)
    //{
    //    Collider[] colliders = Physics.OverlapBox(transform.position, transform.localScale / 2);
    //    foreach (Collider col in colliders)
    //    {
    //        if (col.CompareTag(tag))
    //            return true;
    //    }
    //    return false;
    //}

    void ConfirmCombo()
    {
        //// Remove the trailing underscore
        //combination = combination.TrimEnd('_');

        //// Check if the combination exists in the map
        //if (combinationPrefabMap.ContainsKey(combination))
        //{
        //    // Destroy all objects in the collider
        //    foreach (Collider col in Physics.OverlapBox(transform.position, transform.localScale / 2))
        //    {
        //        Destroy(col.gameObject);
        //    }

        //    // Spawn the corresponding prefab
        //    Instantiate(combinationPrefabMap[combination], transform.position, Quaternion.identity);
        //}

        // Find the recipe that matches the ingredients
        Recipe matchedRecipe = recipes.FirstOrDefault(recipe =>
       new HashSet<CookedIngredients.ingredientType>(recipe.ingredientTypes).SetEquals(ingredients));

        // If a match is found, spawn the corresponding prefab
        if (matchedRecipe.prefab != null)
        {
            GameObject newDish = Instantiate(matchedRecipe.prefab, transform.position, Quaternion.identity);
            //foreach (CookedIngredients.ingredientType i in ingredients)
            //{
            //    Destroy(i);
            //}
            ingredients = new List<CookedIngredients.ingredientType>();
            newDish.transform.localScale = new Vector3(0.3f, 0.3f, 0.3f); // Set the scale as needed
        }

    }
}
