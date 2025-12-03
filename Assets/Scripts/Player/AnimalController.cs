using NUnit.Framework;
using System.Collections.Generic;
using UnityEngine;

public class AnimalController : MonoBehaviour
{
    [SerializeField] float movementSpeed;

    public bool IsMoveTowardsTree { get; private set; }

    private void Update()
    {
        if(CheckForFood() && !IsMoveTowardsTree)
        {
            MoveTowardsFood();
        }

        if(IsMoveTowardsTree)
        {
            MoveTowardsTree();
        }
    }


    public void SetMoveTowardsTree(bool status)
    {
        IsMoveTowardsTree = status;
        Debug.Log("Move Status set to +" + IsMoveTowardsTree);
    }


    bool CheckForFood()
    {
        if(Ground.Instance.foodDropped.Count > 0)
        {
            return true;
        }
        else
        {
            return false;
        }
            
    }

    void MoveTowardsFood()
    {
        this.transform.position += Vector3.right * movementSpeed * Time.deltaTime;
    }


    void MoveTowardsTree()
    {
        this.transform.position += Vector3.left * movementSpeed * Time.deltaTime;
    }

    


    
}
