using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class WinterManager : Singleton<WinterManager>
{
    public static event Action OnWinterChanged;

    [SerializeField] List<int> winterThresholds;

    public int CurrentWinterLevel {  get; private set; }
    public int CurrentWinterLevelThreshold {  get; private set; }
    public int NextWinterLevelThreshold {  get; private set; }


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        SetWinterLevel(0);
    }
    private void OnEnable()
    {
        FoodCounter.OnFoodCounted += CheckWinterLevel;
    }

    private void OnDisable()
    {
        FoodCounter.OnFoodCounted -= CheckWinterLevel;

    }

    public void CheckWinterLevel(List<GameObject> foodItemsDepositedList)
    {
        if(FoodCounter.Instance.TotalPlayerFood >= CurrentWinterLevelThreshold)
        {
            CurrentWinterLevel++;
            SetWinterLevel(CurrentWinterLevel);
            
        }
       
    }

    void SetWinterLevel(int index)
    {
        CurrentWinterLevel = index;
        CurrentWinterLevelThreshold = winterThresholds[CurrentWinterLevel];
        NextWinterLevelThreshold = winterThresholds[CurrentWinterLevel+1];

        OnWinterChanged?.Invoke();
    }


}
