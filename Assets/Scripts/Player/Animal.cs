using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] float baseMovementSpeed;
    [SerializeField] int baseCarryingCapacity;
    [SerializeField] float baseRestTime;
    [SerializeField] float baseDodgeChance;
    [SerializeField] float baseLuck;

    //Animal variables
    public float MovementSpeed { get; private set; }
    public int CarryingCapacity { get; private set; }
    public float RestTime { get; private set; }
    public float DodgeChance { get; private set; }
    public float Luck { get; private set; }



    //Movement variables
    public bool IsMoveTowardsTree { get; private set; }
    public bool IsMoveRight { get; private set; }


    float currentMovementSpeed;

    private void Start()
    {
        UpdateVariables();
    }

    private void OnEnable()
    {
        AnimalStatsManager.OnAnimalSpeedUpdated += UpdateMovementSpeed;
        AnimalStatsManager.OnAnimalCarryingCapacityUpdated += UpdateCarryingCapacity;
        AnimalStatsManager.OnAnimalRestTimeUpdated += UpdateRestTime;
        AnimalStatsManager.OnAnimaDodgeChanceUpdated += UpdateDodgeChance;
        AnimalStatsManager.OnAnimalLuckUpdated += UpdateLuck;
    }

    private void OnDisable()
    {
        AnimalStatsManager.OnAnimalSpeedUpdated -= UpdateMovementSpeed;

    }

    private void Update()
    {
        if((IsFoodOnGround() && !IsMoveTowardsTree) || (!IsFoodOnGround() && !IsMoveTowardsTree))
        {
            MoveRight();
            IsMoveRight = true;
        }
        else
        {
            IsMoveRight = false;
        }

        if (IsMoveTowardsTree && !IsMoveRight)
        {
            MoveTowardsTree();
            IsMoveRight = false;
        }
    }

    

    public void UpdateVariables()
    {
        UpdateMovementSpeed();
        UpdateCarryingCapacity();
        UpdateRestTime();
        UpdateDodgeChance();
        UpdateLuck();

    }

    public void UpdateMovementSpeed()
    {
        MovementSpeed = baseMovementSpeed * (1 + AnimalStatsManager.Instance.AnimalSpeedBonus);
        currentMovementSpeed = MovementSpeed;
        Debug.Log("Move speed: " + MovementSpeed);
    }

    public void UpdateCarryingCapacity()
    {
        CarryingCapacity = baseCarryingCapacity + AnimalStatsManager.Instance.AnimaCarryingCapacityBonus;
        Debug.Log("CarryingCapacity: " + CarryingCapacity);
    }

    public void UpdateRestTime()
    {
        RestTime = baseRestTime * (1 - AnimalStatsManager.Instance.AnimalRestTimeBonus);
        Debug.Log("Rest time: " + RestTime);
    }

    public void UpdateDodgeChance()
    {
        DodgeChance = baseDodgeChance + AnimalStatsManager.Instance.AnimalDodgeBonus;
        Debug.Log("DodgeChance: " + DodgeChance);
    }

    public void UpdateLuck()
    {
        Luck = baseLuck + AnimalStatsManager.Instance.AnimalLuckBonus;
        Debug.Log("Luck: " + Luck);
    }

    public void SetStatusToCoolDown()
    {
        StartCoroutine(RestTimeRoutine());
    }

    IEnumerator RestTimeRoutine()
    {
        currentMovementSpeed = 0f;
        SetMoveTowardsTree(false);
        yield return new WaitForSeconds(RestTime);
        currentMovementSpeed = MovementSpeed;
    }

    public void SetMoveTowardsTree(bool status)
    {
        IsMoveTowardsTree = status;
        //Debug.Log("Move Status set to +" + IsMoveTowardsTree);
    }

    bool IsFoodOnGround()
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

    void MoveRight()
    {
        this.transform.position += Vector3.right * currentMovementSpeed * Time.deltaTime;
    }


    void MoveTowardsTree()
    {
        this.transform.position += Vector3.left * currentMovementSpeed * Time.deltaTime;
    }

    


    
}
