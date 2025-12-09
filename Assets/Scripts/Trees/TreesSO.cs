using System;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TreesSO", menuName = "Scriptable Objects/TreesSO")]
public class TreesSO : ScriptableObject
{
    [Serializable]
    public struct FruitTypes
    {
        public GameObject fruitPrefab;
        public float spawnWeightage;
    }

    public List<FruitTypes> fruits;
    public float intervalBetweenFruitSpawns;

    public GameObject obstaclePrefab;
    public float intervalBetweenObstacleSpawns;

}
