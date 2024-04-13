using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CookedIngredients : MonoBehaviour
{
    public enum ingredientType
    {

        noodle,
        cheese,
        mushroom,
        tomato,
    }

    public ingredientType ing;

    public XRGrabInteractable xRGrabInteractable;

    private void Start()
    {
        xRGrabInteractable = GetComponent<XRGrabInteractable>();
    }
}
