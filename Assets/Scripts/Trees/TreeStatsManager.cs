using System;
using UnityEngine;

public class TreeStatsManager : Singleton<TreeStatsManager>
{
    public static event Action OnTreeFruitSpawnRateUpdated;
    public static event Action OnTreeAdvancedFruitChanceUpdated;
    public static event Action OnTreeObstacleSpawnRateUpdated;
    public static event Action<float,float,int> OnFruitBlossomStarted;


    public float TreeFruitSpawnIntervalBonus { get; private set; }
    public float TreeAdvancedFruitChanceBonus { get; private set; }
    public float TreeObstacleSpawnIntervalBonus { get; private set; }


    protected override void Awake()
    {
        base.Awake();
    }


    public void UpdateFruitSpawnRateBonus(float fruitSpawnIntervalBonus)
    {
        TreeFruitSpawnIntervalBonus += fruitSpawnIntervalBonus;
        Debug.Log("TreeFruitSpawnIntervalBonus: " + TreeFruitSpawnIntervalBonus);
        OnTreeFruitSpawnRateUpdated?.Invoke();
    }

    public void UpdateAdvancedFruitChanceBonus(float advancedFruitChanceBonus)
    {
        TreeAdvancedFruitChanceBonus += advancedFruitChanceBonus;
        Debug.Log("TreeAdvancedFruitChanceBonus: " + TreeAdvancedFruitChanceBonus);
        OnTreeAdvancedFruitChanceUpdated?.Invoke();
    }

    public void UpdateObstacleSpawnRateBonus(float obstacleSpawnIntervalBonus)
    {
        TreeObstacleSpawnIntervalBonus += obstacleSpawnIntervalBonus;
        Debug.Log("TreeObstacleSpawnIntervalBonus: " + TreeObstacleSpawnIntervalBonus);
        OnTreeObstacleSpawnRateUpdated?.Invoke();
    }

    public void StartFruitBlossom(float blossomInterval, float blossomChance, int blossomNumberOfFruits)
    {
        Debug.Log("Starting Blossom...");
        OnFruitBlossomStarted?.Invoke(blossomInterval, blossomChance, blossomNumberOfFruits);
    }

}
