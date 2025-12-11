using UnityEngine;

[CreateAssetMenu(fileName = "FoodSO", menuName = "Scriptable Objects/FoodSO")]
public class FoodSO : ScriptableObject
{
    [System.Serializable]
    public enum Category
    {
        Nuts,
    }

    [System.Serializable]
    public enum Type
    {
        BasicNut,
        SilverNut,
        MagicNut
    }

    public Category foodCategory;
    public Type foodType;
    public float foodQuantity;
    public float seedQuantity;
    public float lifeEssenceQuantity;
}
