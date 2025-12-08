using UnityEngine;

public class AnimalsManager : Singleton<AnimalsManager>
{
    protected override void Awake()
    {
        base.Awake();
    }


    public void AddAnimal(GameObject animalToBeAdded)
    {
        GameObject animal = Instantiate(animalToBeAdded, this.transform);
    }

}
