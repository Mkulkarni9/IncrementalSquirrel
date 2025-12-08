using System;
using UnityEngine;

public class AnimalStatsManager : Singleton<AnimalStatsManager>
{

    public static event Action OnAnimalSpeedUpdated;
    public static event Action OnAnimalCarryingCapacityUpdated;
    public static event Action OnAnimalRestTimeUpdated;
    public static event Action OnAnimaDodgeChanceUpdated;
    public static event Action OnAnimalLuckUpdated;



    public float AnimalSpeedBonus { get; private set; }
    public int AnimaCarryingCapacityBonus { get; private set; }
    public float AnimalRestTimeBonus { get; private set; }
    public float AnimalDodgeBonus { get; private set; }
    public float AnimalLuckBonus { get; private set; }

    protected override void Awake()
    {
        base.Awake();
    }
    
    
    public void UpdateAnimalSpeedBonus(float animalSpeedBonus)
    {
        AnimalSpeedBonus = animalSpeedBonus;
        Debug.Log("Animal speed bonus updated: "+ AnimalSpeedBonus);
        OnAnimalSpeedUpdated?.Invoke();
    }

    public void UpdateAnimalCarryingCapacityBonus(int animalCarryingCapacityBonus)
    {
        AnimaCarryingCapacityBonus += animalCarryingCapacityBonus;
        OnAnimalCarryingCapacityUpdated?.Invoke();

    }

    public void UpdateAnimalRestTimeBonus(float animalRestTimeBonus)
    {
        AnimalRestTimeBonus = animalRestTimeBonus;
        OnAnimalRestTimeUpdated?.Invoke();

    }

    public void UpdateAnimalDodgeChanceBonus(float animalDodgeBonus)
    {
        AnimalDodgeBonus = animalDodgeBonus;
        OnAnimaDodgeChanceUpdated?.Invoke();

    }

    public void UpdateAnimalLuckBonus(float animalLuckBonus)
    {
        AnimalLuckBonus = animalLuckBonus;
        OnAnimalLuckUpdated?.Invoke();

    }


}
