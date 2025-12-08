using UnityEngine;

public class AddAnimalSkill : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AddAnimalSkillSO addAnimalSkill)
        {
            AnimalsManager.Instance.AddAnimal(addAnimalSkill.animalPrefab);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
