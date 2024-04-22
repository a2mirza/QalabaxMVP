using UnityEngine;

public class WaterFillUp : MonoBehaviour
{
    public Material wokWaterMaterial;
    public float maxFillValue = 0.2f;
    private float currentFillValue = -0.5f;

    private bool canCook;

    private void Start()
    {
        SetFillValue(currentFillValue);
        canCook = false;
    }

    private void Update()
    {
        currentFillValue = Mathf.Clamp(currentFillValue, -0.5f, maxFillValue);
        SetFillValue(currentFillValue);

        if (currentFillValue <= maxFillValue)
        {
            canCook = true;
        }
    }

    

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("WaterSprinkles"))
        {
            IncreaseFillValue();
            Destroy(other.gameObject);
        }
    }

    private void IncreaseFillValue()
    {
        // Only increase fill value if below max
        if (currentFillValue < maxFillValue)
        {
            currentFillValue += 0.25f; //
        }
    }

    private void SetFillValue(float value)
    {
        if (wokWaterMaterial != null)
        {
            wokWaterMaterial.SetFloat("_Fill", value);
        }
    }
}
