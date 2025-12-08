using System;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class FoodCounter : Singleton<FoodCounter>
{
    public static event Action<List<GameObject>> OnFoodCounted;
    public int TotalPlayerFood { get; private set; }
    public int TotalPlayerSeeds { get; private set; }

    int foodDepositedThisRound;
    int seedsDepositedThisRound;

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

        foreach (GameObject foodItemDeposited in foodItemsDepositedList)
        {
            CalculateFoodDeposited(foodItemDeposited.GetComponent<Food>().FoodSO.foodQuantity);
            CalculateSeedsDeposited(foodItemDeposited.GetComponent<Food>().FoodSO.seedQuantity);
        }

        TotalPlayerFood += foodDepositedThisRound;
        TotalPlayerSeeds += seedsDepositedThisRound;

        Debug.Log("Total player food: "+ TotalPlayerFood);
        Debug.Log("Total player seeds: "+ TotalPlayerSeeds);

        OnFoodCounted?.Invoke(foodItemsDepositedList);
    }


    void CalculateFoodDeposited(int foodQuantity)
    {
        foodDepositedThisRound += foodQuantity;
    }

    void CalculateSeedsDeposited(int seedQuantity)
    {
        seedsDepositedThisRound += seedQuantity;
    }

    
}
