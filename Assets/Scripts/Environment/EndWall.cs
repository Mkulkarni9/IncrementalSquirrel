using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        AnimalController animalController = collision.gameObject.GetComponent<AnimalController>();
        if (animalController!=null)
        {
            animalController.SetMoveTowardsTree(true);


        }
    }
}
