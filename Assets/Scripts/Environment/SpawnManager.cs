using System.Collections;
using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    [SerializeField] GameObject foodPrefab;
    [SerializeField] GameObject branchGameObject;
    [SerializeField] float timeIntervalBetweenFoodSpawns;


    Coroutine foodSpawnRoutine;


    private void Start()
    {
        SpawnFood();
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
            float spawnObjectLeftBound = branchGameObject.GetComponent<Collider2D>().bounds.min.x;
            float spawnObjectRightBound = branchGameObject.GetComponent<Collider2D>().bounds.max.x;
            float spawnObjectBottomBound = branchGameObject.GetComponent<Collider2D>().bounds.min.y;

            float spawnXPosition = Random.Range(spawnObjectLeftBound, spawnObjectRightBound);
            Instantiate(foodPrefab, new Vector2(spawnXPosition, spawnObjectBottomBound - 0.5f), Quaternion.identity);

            yield return new WaitForSeconds(timeIntervalBetweenFoodSpawns);
        }
    }

}
