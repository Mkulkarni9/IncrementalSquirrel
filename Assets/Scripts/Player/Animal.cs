using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Animal : MonoBehaviour
{
    [SerializeField] AnimalSO animalSO;

    //Animal variables
    public float MovementSpeed { get; private set; }
    public int CarryingCapacity { get; private set; }
    public float RestTime { get; private set; }
    public float DodgeChance { get; private set; }
    public float Luck { get; private set; }
    public float SlowdownSpeedTimeReduction { get; private set; }
    public float SlowdownSpeedAmountReduction { get; private set; }



    //Movement variables
    public bool IsMoveTowardsTree { get; private set; }
    public bool IsMoveRight { get; private set; }


    float currentMovementSpeed;


    Coroutine slowMovementRoutine;

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
        AnimalStatsManager.OnAnimalSlowdownSpeedTimeReductionUpdated += UpdateSlowdownSpeedTimeReduction;
    }

    private void OnDisable()
    {
        AnimalStatsManager.OnAnimalSpeedUpdated -= UpdateMovementSpeed;
        AnimalStatsManager.OnAnimalCarryingCapacityUpdated -= UpdateCarryingCapacity;
        AnimalStatsManager.OnAnimalRestTimeUpdated -= UpdateRestTime;
        AnimalStatsManager.OnAnimaDodgeChanceUpdated -= UpdateDodgeChance;
        AnimalStatsManager.OnAnimalLuckUpdated -= UpdateLuck;
        AnimalStatsManager.OnAnimalSlowdownSpeedTimeReductionUpdated -= UpdateSlowdownSpeedTimeReduction;

    }

    private void Update()
    {
        if(!IsMoveTowardsTree)
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
        MovementSpeed = animalSO.baseMovementSpeed * (1 + AnimalStatsManager.Instance.AnimalSpeedBonus);
        currentMovementSpeed = MovementSpeed;
        Debug.Log("Move speed: " + MovementSpeed);
    }

    public void UpdateCarryingCapacity()
    {
        CarryingCapacity = animalSO.baseCarryingCapacity + AnimalStatsManager.Instance.AnimaCarryingCapacityBonus;
        Debug.Log("CarryingCapacity: " + CarryingCapacity);
    }

    public void UpdateRestTime()
    {
        RestTime = animalSO.baseRestTime * (1 - AnimalStatsManager.Instance.AnimalRestTimeBonus);
        Debug.Log("Rest time: " + RestTime);
    }

    public void UpdateDodgeChance()
    {
        DodgeChance = animalSO.baseDodgeChance + AnimalStatsManager.Instance.AnimalDodgeBonus;
        Debug.Log("DodgeChance: " + DodgeChance);
    }

    public void UpdateLuck()
    {
        Luck = animalSO.baseLuck + AnimalStatsManager.Instance.AnimalLuckBonus;
        Debug.Log("Luck: " + Luck);
    }

    public void UpdateSlowdownSpeedTimeReduction()
    {
        SlowdownSpeedTimeReduction = AnimalStatsManager.Instance.SlowdownSpeedTimeReduction;

        Debug.Log("SlowdownSpeedTimeReduction: " + SlowdownSpeedTimeReduction);
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

    
    public void SlowMovementSpeed(float amountSlowed, float timeSlowed)
    {
        float dodgeRandomNumber = Random.Range(0, 1f);

        if(dodgeRandomNumber > DodgeChance)
        {
            if (slowMovementRoutine != null)
            {
                StopCoroutine(slowMovementRoutine);
            }

            float effectiveAmountSlowed = amountSlowed * (1- SlowdownSpeedAmountReduction);
            float effectiveTimeSlowed = timeSlowed * (1- SlowdownSpeedTimeReduction);

            slowMovementRoutine = StartCoroutine(SlowMovementRoutine(effectiveAmountSlowed, effectiveTimeSlowed));
        }
        else
        {
            Debug.Log("Dodged obstacle!!");
        }

        
    }

    IEnumerator SlowMovementRoutine(float amountSlowed, float timeSlowed)
    {
        currentMovementSpeed = MovementSpeed * (1 - amountSlowed);
        Debug.Log("Move speed after slowing down: "+ currentMovementSpeed);
        yield return new WaitForSeconds(timeSlowed);
        currentMovementSpeed = MovementSpeed;
        Debug.Log("Resetting move speed: " + currentMovementSpeed);
    }

    
}
