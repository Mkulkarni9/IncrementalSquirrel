using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] TreesSO treeSO;


    //Tree Variables
    public float FruitSpawnRate { get; private set; }

    Coroutine foodSpawnRoutine;


    private void OnEnable()
    {
        TreeStatsManager.OnTreeFruitSpawnRateUpdated += UpdateFruitSpawnRate;
    }


    private void OnDisable()
    {
        TreeStatsManager.OnTreeFruitSpawnRateUpdated -= UpdateFruitSpawnRate;

    }
    private void Start()
    {
        UpdateVariables();

        SpawnFood();
    }

    public void UpdateVariables()
    {
        UpdateFruitSpawnRate();
    }




    void UpdateFruitSpawnRate()
    {
        FruitSpawnRate = treeSO.intervalBetweenFruitSpawns * (1 - TreeStatsManager.Instance.TreeFruitSpawnIntervalBonus);
        Debug.Log("Fruit spawn rate: "+ FruitSpawnRate);
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
            
            Quaternion spawnQuaternion = Quaternion.Euler(0f,0f,Random.Range(0f,180f));
            Instantiate(treeSO.fruits[foodIndex].fruitPrefab, new Vector2(spawnXPosition, spawnObjectBottomBound - 0.5f), spawnQuaternion);

        }
    }


    int GetRandomIndex()
    {
        float sumWeights = 0;
        
        for (int i = 0; i < treeSO.fruits.Count; i++)
        {
            sumWeights += treeSO.fruits[i].spawnWeightage;
        }

        float randomNumber = Random.Range(0f, 1f);

        float sumProbabilities = 0;
        for (int i = 0; i < treeSO.fruits.Count; i++)
        {
            sumProbabilities += treeSO.fruits[i].spawnWeightage / sumWeights;

            if (randomNumber <= sumProbabilities)
            {
                return i;
            }
        }

        return -1;
    }

}
