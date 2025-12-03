using UnityEngine;

public class Food : MonoBehaviour
{
    [SerializeField] FoodSO foodSO;

    public FoodSO FoodSO => foodSO;
}
