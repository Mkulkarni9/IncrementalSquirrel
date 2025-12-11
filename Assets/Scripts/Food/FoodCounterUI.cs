using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class FoodCounterUI : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winterCountText;
    [SerializeField] TextMeshProUGUI foodAmountText;
    [SerializeField] TextMeshProUGUI seedAmountText;
    [SerializeField] TextMeshProUGUI lifeEssenceAmountText;




    private void OnEnable()
    {
        FoodCounter.OnFoodCounted += UpdateUI;
        WinterManager.OnWinterChanged += UpdateFoodUI;
    }

    private void OnDisable()
    {
        FoodCounter.OnFoodCounted -= UpdateUI;
        WinterManager.OnWinterChanged += UpdateFoodUI;

    }

    private void Start()
    {
    }

    void UpdateUI(List<GameObject> foodItemsCountedList)
    {
        UpdateFoodUI();
        UpdateSeedsUI();
        UpdateLifeEssenceUI();
    }


    void UpdateFoodUI()
    {
        winterCountText.text = "Winter: " + (WinterManager.Instance.CurrentWinterLevel + 1);
        foodAmountText.text = FoodCounter.Instance.TotalPlayerFood.ToString() + " / " + WinterManager.Instance.CurrentWinterLevelThreshold;
    }


    void UpdateSeedsUI()
    {
        seedAmountText.text = FoodCounter.Instance.TotalPlayerSeeds.ToString();



    }
    void UpdateLifeEssenceUI()
    {
        lifeEssenceAmountText.text = FoodCounter.Instance.TotalPlayerLifeEssence.ToString();
    }
}
