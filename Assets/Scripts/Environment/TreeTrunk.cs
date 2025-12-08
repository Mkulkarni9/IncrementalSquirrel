using System;
using System.Collections.Generic;
using UnityEngine;

public class TreeTrunk : MonoBehaviour
{
    public static event Action<List<GameObject>> OnFoodDeposited;



    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animal animal = collision.gameObject.GetComponent<Animal>();
        Debug.Log("Collision with animal");
        if (animal != null)
        {
            animal.SetStatusToCoolDown();

            foreach (var item in animal.GetComponentInChildren<FoodCollection>().FoodCarried)
            {
                Debug.Log("item in list" + item.GetComponent<Food>().FoodSO.foodQuantity);
            }

            OnFoodDeposited?.Invoke(animal.GetComponentInChildren<FoodCollection>().FoodCarried);
            animal.GetComponentInChildren<FoodCollection>().RemoveFoodFromAnimal(animal.GetComponentInChildren<FoodCollection>().FoodCarried);
        }
    }

    
}
