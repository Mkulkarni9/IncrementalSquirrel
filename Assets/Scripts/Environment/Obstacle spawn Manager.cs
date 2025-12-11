using System.Collections;
using UnityEngine;

public class ObstaclespawnManager : MonoBehaviour
{
    [SerializeField] TreesSO treeSO;

    public float ObstacleSpawnRate { get; private set; }


    Coroutine obstacleSpawnRoutine;


    private void OnEnable()
    {
        TreeStatsManager.OnTreeObstacleSpawnRateUpdated += UpdateObstacleSpawnRate;
    }

    private void OnDisable()
    {
        TreeStatsManager.OnTreeObstacleSpawnRateUpdated -= UpdateObstacleSpawnRate;

    }

    private void Start()
    {
        UpdateVariables();

        SpawnObstacle();
    }

    public void UpdateVariables()
    {
        UpdateObstacleSpawnRate();
    }

    void UpdateObstacleSpawnRate()
    {
        ObstacleSpawnRate = treeSO.intervalBetweenObstacleSpawns * (1 + TreeStatsManager.Instance.TreeObstacleSpawnIntervalBonus);
        Debug.Log("Obstacle spawn rate: " + ObstacleSpawnRate);
    }



    public void SpawnObstacle()
    {
        if (obstacleSpawnRoutine != null)
        {
            StopCoroutine(obstacleSpawnRoutine);
        }

        obstacleSpawnRoutine = StartCoroutine(SpawnObstacleRoutine());
    }


    IEnumerator SpawnObstacleRoutine()
    {

        while (true)
        {
            yield return new WaitForSeconds(treeSO.intervalBetweenObstacleSpawns);

            float spawnObjectLeftBound = this.gameObject.GetComponent<Collider2D>().bounds.min.x;
            float spawnObjectRightBound = this.gameObject.GetComponent<Collider2D>().bounds.max.x;
            float spawnObjectBottomBound = this.gameObject.GetComponent<Collider2D>().bounds.min.y;

            float spawnXPosition = Random.Range(spawnObjectLeftBound, spawnObjectRightBound);
            Instantiate(treeSO.obstaclePrefab, new Vector2(spawnXPosition, spawnObjectBottomBound - 0.5f), Quaternion.identity);

        }
    }
}
