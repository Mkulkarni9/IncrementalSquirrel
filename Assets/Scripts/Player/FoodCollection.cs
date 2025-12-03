using System;
using System.Collections.Generic;
using UnityEngine;

public class FoodCollection : MonoBehaviour
{
    public static event Action<GameObject> OnFoodCollected;

    [SerializeField] int carryingCapacity;


    public List<GameObject> FoodCarried = new List<GameObject>();
    float heightOfCollector = 0.5f;
    float heightOfEachFoodItem = 1f;


    private void OnEnable()
    {
        FoodCounter.OnFoodCounted += RemoveFoodFromAnimal;
    }

    private void OnDisable()
    {
        FoodCounter.OnFoodCounted -= RemoveFoodFromAnimal;

    }
    

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Food>() != null && !CheckCarryingCapacity())
        {
            FoodCarried.Add(collision.gameObject);
            AttachCollectedFoodToCollector(collision.gameObject, FoodCarried.Count);

            OnFoodCollected?.Invoke(collision.gameObject);

            if (CheckCarryingCapacity())
            {
                this.GetComponentInParent<AnimalController>().SetMoveTowardsTree(true);
            }

        }
    }

    bool CheckCarryingCapacity()
    {
        if (FoodCarried.Count == carryingCapacity)
        {
            return true;
        }
        else return false;
    }

    void RemoveFoodCollidersAfterCollection(GameObject food)
    {
        food.GetComponent<Collider2D>().enabled = false;
    }

    void AttachCollectedFoodToCollector(GameObject food, int itemIndex)
    {
        Destroy(food.GetComponent<Rigidbody2D>());
        food.GetComponent<Collider2D>().enabled= false;

        float yValueOfFood = heightOfCollector + heightOfEachFoodItem * itemIndex;
        food.transform.SetParent(this.gameObject.transform);

        //Setting position
        food.transform.localPosition= new Vector3(0f, yValueOfFood);
        
        //Setting rotation
        Quaternion eulerAngles = Quaternion.Euler(0, 0, 0);
        food.transform.rotation= eulerAngles;

        //Setting scale
        //food.transform.localScale = new Vector3(0.8f, 0.8f, 1f);
    }

    public void RemoveFoodFromAnimal(List<GameObject> foodItemsCountedList)
    {
        FoodCarried.Clear();
        Debug.Log("Food removed from animal");
    }
}
