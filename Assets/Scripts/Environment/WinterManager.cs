using NUnit.Framework;
using System;
using System.Collections.Generic;
using TMPro.EditorUtilities;
using UnityEngine;

public class WinterManager : Singleton<WinterManager>
{
    public static event Action<int> OnWinterChanged;

    [SerializeField] List<int> winterThresholds;

    public int CurrentWinterLevel {  get; private set; }
    public int CurrentWinterLevelThreshold {  get; private set; }


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
        OnWinterChanged += SetWinterLevel;
    }

    private void OnDisable()
    {
        FoodCounter.OnFoodCounted -= CheckWinterLevel;
        OnWinterChanged -= SetWinterLevel;


    }

    public void CheckWinterLevel(List<GameObject> foodItemsDepositedList)
    {
        if(FoodCounter.Instance.TotalPlayerFood >= CurrentWinterLevelThreshold)
        {
            OnWinterChanged?.Invoke(++CurrentWinterLevel);
        }
       
    }

    void SetWinterLevel(int index)
    {
        CurrentWinterLevel = index;
        CurrentWinterLevelThreshold = winterThresholds[CurrentWinterLevel];
    }


}
