using System;
using UnityEngine;

public class FruitStatsManager : Singleton<FruitStatsManager>
{

    public static event Action OnFoodQtyBonusUpdated;
    public static event Action OnSeedQtyBonusUpdated;
    public static event Action OnLifeEssenceQtyBonusUpdated;



    public float FoodQtyBonus { get; private set; }
    public float SeedQtyBonus { get; private set; }
    public float LifeEssenceQtyBonus { get; private set; }



    protected override void Awake()
    {
        base.Awake();
    }

    


    public void UpdateFoodQtyBonus(float foodQtyBonus)
    {
        FoodQtyBonus += foodQtyBonus;
        Debug.Log("FoodQtyBonus updated: " + FoodQtyBonus);
        OnFoodQtyBonusUpdated?.Invoke();
    }

    public void UpdateSeedQtyBonus(float seedQtyBonus)
    {
        SeedQtyBonus += seedQtyBonus;
        Debug.Log("SeedQtyBonus updated: " + SeedQtyBonus);
        OnSeedQtyBonusUpdated?.Invoke();
    }

    public void UpdateLifeEssenceQtyBonus(float lifeEssenceQtyBonus)
    {
        LifeEssenceQtyBonus += lifeEssenceQtyBonus;
        Debug.Log("LifeEssenceQtyBonus updated: " + LifeEssenceQtyBonus);
        OnLifeEssenceQtyBonusUpdated?.Invoke();
    }

}
