using System.Diagnostics.Contracts;
using UnityEngine;

[CreateAssetMenu(fileName = "AnimalSO", menuName = "Scriptable Objects/AnimalSO")]
public class AnimalSO : ScriptableObject
{
    [System.Serializable]
    public enum Category
    {
        Land,
        Air
    }

    [System.Serializable]
    public enum Type
    {
        Squirrel,
        Deer,
        Bird1
    }

    public Category category;
    public Type type;

    public float baseMovementSpeed;
    public int baseCarryingCapacity;
    public float baseRestTime;
    public float baseDodgeChance;
    public float baseLuck;
}
