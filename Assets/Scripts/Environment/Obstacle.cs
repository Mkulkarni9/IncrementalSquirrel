using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Obstacle : MonoBehaviour
{

    [SerializeField] ObstacleSO obstacleSO;

    bool isOnGround;

    private void Update()
    {
        if(!isOnGround)
        {
            Fall();
        }
        
    }

    void Fall()
    {
        this.transform.position += Vector3.down * Time.deltaTime* obstacleSO.fallSpeed;
    }

    

    public void CollidedWithGround()
    {
        isOnGround = true;
        StartCoroutine(DisappearFoodRoutine());
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        

        if (collision.gameObject.GetComponent<Animal>() != null)
        {
            collision.gameObject.GetComponent<Animal>().SlowMovementSpeed(obstacleSO.amountSlowed, obstacleSO.timeSlowed);
        }
    }
    



    IEnumerator DisappearFoodRoutine()
    {
        yield return new WaitForSeconds(obstacleSO.secondsBeforeDisappear);
        Destroy(this.gameObject);
    }



}
