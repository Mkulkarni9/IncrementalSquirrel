using Unity.VisualScripting;
using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] FoodSO foodSO;

    public float FoodQty { get; private set; }
    public float SeedQty { get; private set; }
    public float LifeEssenceQty { get; private set; }


    private void OnEnable()
    {
        FruitStatsManager.OnFoodQtyBonusUpdated += UpdateFoodQty;
        FruitStatsManager.OnSeedQtyBonusUpdated += UpdateSeedQty;
        FruitStatsManager.OnLifeEssenceQtyBonusUpdated += UpdateLifeEssenceQty;
    }

    private void OnDisable()
    {
        FruitStatsManager.OnFoodQtyBonusUpdated -= UpdateFoodQty;
        FruitStatsManager.OnSeedQtyBonusUpdated -= UpdateSeedQty;
        FruitStatsManager.OnLifeEssenceQtyBonusUpdated -= UpdateLifeEssenceQty;
    }


    private void Start()
    {
        UpdateVariables();
    }

    private void UpdateVariables()
    {
        UpdateFoodQty();
        UpdateSeedQty();
        UpdateLifeEssenceQty();

    }

    public void UpdateFoodQty()
    {
        FoodQty = foodSO.foodQuantity * (1 + FruitStatsManager.Instance.FoodQtyBonus);
        //Debug.Log("FoodQty: " + FoodQty);
    }

    public void UpdateSeedQty()
    {
        SeedQty = foodSO.seedQuantity * (1 + FruitStatsManager.Instance.SeedQtyBonus);
        //Debug.Log("SeedQty: " + SeedQty);
    }

    public void UpdateLifeEssenceQty()
    {
        LifeEssenceQty = foodSO.lifeEssenceQuantity * (1 + FruitStatsManager.Instance.LifeEssenceQtyBonus);
        //Debug.Log("LifeEssenceQty: " + LifeEssenceQty);
    }



}
