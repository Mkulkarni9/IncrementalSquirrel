using UnityEngine;

public class EndWall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Animal animalController = collision.gameObject.GetComponent<Animal>();
        if (animalController!=null)
        {
            animalController.SetMoveTowardsTree(true);


        }
    }
}
