using System;
using UnityEngine;

public class TreeStatsManager : Singleton<TreeStatsManager>
{
    public static event Action OnTreeFruitSpawnRateUpdated;


    public float TreeFruitSpawnIntervalBonus { get; private set; }


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

}
