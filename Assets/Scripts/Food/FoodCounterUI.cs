using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodCounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winterCountText;
    [SerializeField] TextMeshProUGUI foodAmountText;
    [SerializeField] TextMeshProUGUI seedAmountText;




    private void OnEnable()
    {
        FoodCounter.OnFoodCounted += UpdateFoodUI;
        FoodCounter.OnFoodCounted += UpdateSeedsUI;
    }

    private void OnDisable()
    {
        FoodCounter.OnFoodCounted -= UpdateFoodUI;
        FoodCounter.OnFoodCounted -= UpdateSeedsUI;
    }

    private void Start()
    {
        UpdateFoodUI(null);
        UpdateSeedsUI(null);
    }


    void UpdateFoodUI(List<GameObject> foodItemsCountedList)
    {
        winterCountText.text = "Winter: "+WinterManager.Instance.CurrentWinterLevel;
        foodAmountText.text = FoodCounter.Instance.TotalPlayerFood.ToString() + " / " + WinterManager.Instance.CurrentWinterLevelThreshold;
    }


    void UpdateSeedsUI(List<GameObject> foodItemsCountedList)
    {
        seedAmountText.text = FoodCounter.Instance.TotalPlayerSeeds.ToString();
    }
}
