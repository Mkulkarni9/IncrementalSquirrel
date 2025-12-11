using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FoodCounter : Singleton<FoodCounter>
{
    public static event Action<List<GameObject>> OnFoodCounted;
    public float TotalPlayerFood { get; private set; }
    public float TotalPlayerSeeds { get; private set; }
    public float TotalPlayerLifeEssence { get; private set; }

    float foodDepositedThisRound;
    float seedsDepositedThisRound;
    float lifeEssenceDepositedThisRound;

    private void OnEnable()
    {
        TreeTrunk.OnFoodDeposited += UpdateFoodCount;
    }

    private void OnDisable()
    {
        TreeTrunk.OnFoodDeposited -= UpdateFoodCount;
    }


    public void UpdateFoodCount(List<GameObject> foodItemsDepositedList)
    {
        foodDepositedThisRound = 0;
        seedsDepositedThisRound = 0;
        lifeEssenceDepositedThisRound = 0;

        foreach (GameObject foodItemDeposited in foodItemsDepositedList)
        {
            CalculateFoodDeposited(foodItemDeposited.GetComponent<Food>().FoodQty);
            CalculateSeedsDeposited(foodItemDeposited.GetComponent<Food>().SeedQty);
            CalculateLifeEssenceDeposited(foodItemDeposited.GetComponent<Food>().LifeEssenceQty);
        }

        TotalPlayerFood += foodDepositedThisRound;
        TotalPlayerSeeds += seedsDepositedThisRound;
        TotalPlayerLifeEssence += lifeEssenceDepositedThisRound;

        //Debug.Log("Total player food: "+ TotalPlayerFood);
        //Debug.Log("Total player seeds: "+ TotalPlayerSeeds);

        OnFoodCounted?.Invoke(foodItemsDepositedList);
    }


    void CalculateFoodDeposited(float foodQuantity)
    {
        foodDepositedThisRound += foodQuantity;
    }

    void CalculateSeedsDeposited(float seedQuantity)
    {
        seedsDepositedThisRound += seedQuantity;
    }

    void CalculateLifeEssenceDeposited(float lifeEssenceQuantity)
    {
        lifeEssenceDepositedThisRound += lifeEssenceQuantity;
    }


}
