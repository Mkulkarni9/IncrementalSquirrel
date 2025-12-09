using System.Collections;
using UnityEngine;

public class ObstaclespawnManager : MonoBehaviour
{
    [SerializeField] TreesSO treeSO;


    Coroutine obstacleSpawnRoutine;


    private void Start()
    {
        SpawnObstacle();
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
