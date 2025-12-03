using System.Collections.Generic;
using UnityEngine;

public class Ground : Singleton<Ground>
{
    public List<GameObject> foodDropped;


    private void OnEnable()
    {
        FoodCollection.OnFoodCollected += RemoveFoodFromGround;
    }

    private void OnDisable()
    {
        FoodCollection.OnFoodCollected -= RemoveFoodFromGround;

    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<Food>() !=null)
        {
            foodDropped.Add(collision.gameObject);
        }
    }

    public void RemoveFoodFromGround(GameObject foodCollected)
    {
        foodDropped.Remove(foodCollected);
    }
}
