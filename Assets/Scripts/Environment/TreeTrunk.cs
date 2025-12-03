using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrunk : MonoBehaviour
{
    public static event Action<List<GameObject>> OnFoodDeposited;



    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalController animal = collision.gameObject.GetComponent<AnimalController>();
        Debug.Log("Collision with animal");
        if (animal != null)
        {
            animal.SetMoveTowardsTree(false);

            foreach (var item in animal.GetComponentInChildren<FoodCollection>().FoodCarried)
            {
                Debug.Log("item in list" + item.GetComponent<Food>().FoodSO.foodQuantity);
            }

            OnFoodDeposited?.Invoke(animal.GetComponentInChildren<FoodCollection>().FoodCarried);
        }
    }

    
}
