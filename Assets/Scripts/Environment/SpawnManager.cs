using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] TreesSO treeSO;


    //Tree Variables
    public float FruitSpawnRate { get; private set; }
    public List<float> SpawnWeightages { get; private set; } = new List<float>();
    public float AdvancedFruitWeightage { get; private set; }

    Coroutine foodSpawnRoutine;
    Coroutine blossomRoutine;


    private void OnEnable()
    {
        TreeStatsManager.OnTreeFruitSpawnRateUpdated += UpdateFruitSpawnRate;
        TreeStatsManager.OnTreeAdvancedFruitChanceUpdated += UpdateAdvancedFruitChanceRate;
        TreeStatsManager.OnFruitBlossomStarted += StartFruitBlossom;
    }


    private void OnDisable()
    {
        TreeStatsManager.OnTreeFruitSpawnRateUpdated -= UpdateFruitSpawnRate;
        TreeStatsManager.OnTreeAdvancedFruitChanceUpdated -= UpdateAdvancedFruitChanceRate;
        TreeStatsManager.OnFruitBlossomStarted -= StartFruitBlossom;



    }
    private void Start()
    {
        UpdateVariables();

        SpawnFood();
    }

    public void UpdateVariables()
    {
        UpdateFruitSpawnRate();
        UpdateAdvancedFruitChanceRate();
    }




    void UpdateFruitSpawnRate()
    {
        FruitSpawnRate = treeSO.intervalBetweenFruitSpawns * (1 - TreeStatsManager.Instance.TreeFruitSpawnIntervalBonus);
        Debug.Log("Fruit spawn rate: "+ FruitSpawnRate);
    }

    void UpdateAdvancedFruitChanceRate()
    {
        SpawnWeightages.Clear();
        for (int i = 0; i < treeSO.fruits.Count; i++)
        {

            if (i < treeSO.fruits.Count - 1)
            {
                SpawnWeightages.Add(treeSO.fruits[i].spawnWeightage);
                
            }
            else
            {
                SpawnWeightages.Add(treeSO.fruits[i].spawnWeightage + TreeStatsManager.Instance.TreeAdvancedFruitChanceBonus);
                //Debug.Log("Advance Fruit weightage: " + SpawnWeightages[i]);
            }
        }

        
    }



    public void SpawnFood()
    {
        if(foodSpawnRoutine !=null)
        {
            StopCoroutine(foodSpawnRoutine);
        }

        foodSpawnRoutine = StartCoroutine(SpawnFoodRoutine());
    }


    IEnumerator SpawnFoodRoutine()
    {
        
        while(true)
        {
            yield return new WaitForSeconds(FruitSpawnRate);

            float spawnObjectLeftBound = this.gameObject.GetComponent<Collider2D>().bounds.min.x;
            float spawnObjectRightBound = this.gameObject.GetComponent<Collider2D>().bounds.max.x;
            float spawnObjectBottomBound = this.gameObject.GetComponent<Collider2D>().bounds.min.y;

            float spawnXPosition = Random.Range(spawnObjectLeftBound, spawnObjectRightBound);

            int foodIndex = GetRandomIndex();
            //Debug.Log("Index: "+ foodIndex);
            Quaternion spawnQuaternion = Quaternion.Euler(0f,0f,Random.Range(0f,180f));
            Instantiate(treeSO.fruits[foodIndex].fruitPrefab, new Vector2(spawnXPosition, spawnObjectBottomBound - 0.5f), spawnQuaternion);

        }
    }


    int GetRandomIndex()
    {
        float sumWeights = 0;
        
        for (int i = 0; i < SpawnWeightages.Count; i++)
        {
            sumWeights += SpawnWeightages[i];
        }

        float randomNumber = Random.Range(0f, 1f);

        //Debug.Log($"Random number: {randomNumber}");

        float sumProbabilities = 0;
        for (int i = 0; i < SpawnWeightages.Count; i++)
        {
            sumProbabilities += SpawnWeightages[i] / sumWeights;

            if (randomNumber <= sumProbabilities)
            {
                return i;
            }
        }

        return -1;
    }

    public void StartFruitBlossom(float blossomInterval, float blossomChance, int blossomNumberOfFruits)
    {
        if (blossomRoutine != null)
        {
            StopCoroutine(blossomRoutine);
        }

        blossomRoutine = StartCoroutine(BlossomRoutine(blossomInterval, blossomChance, blossomNumberOfFruits));
    }


    IEnumerator BlossomRoutine(float blossomInterval, float blossomChance, int blossomNumberOfFruits)
    {
        while (true)
        {
            yield return new WaitForSeconds(blossomInterval);

            float randomNumber = Random.Range(0f, 1f);
            if(randomNumber<= blossomChance)
            {
                for (int i = 0; i < blossomNumberOfFruits; i++)
                {
                    float spawnObjectLeftBound = this.gameObject.GetComponent<Collider2D>().bounds.min.x;
                    float spawnObjectRightBound = this.gameObject.GetComponent<Collider2D>().bounds.max.x;
                    float spawnObjectBottomBound = this.gameObject.GetComponent<Collider2D>().bounds.min.y;

                    float spawnXPosition = Random.Range(spawnObjectLeftBound, spawnObjectRightBound);

                    int foodIndex = GetRandomIndex();
                    //Debug.Log("Index: "+ foodIndex);
                    Quaternion spawnQuaternion = Quaternion.Euler(0f, 0f, Random.Range(0f, 180f));
                    Instantiate(treeSO.fruits[foodIndex].fruitPrefab, new Vector2(spawnXPosition, spawnObjectBottomBound - 0.5f), spawnQuaternion);
                    yield return new WaitForSeconds(0.05f);
                }
                
            }

            

        }
    }

}
