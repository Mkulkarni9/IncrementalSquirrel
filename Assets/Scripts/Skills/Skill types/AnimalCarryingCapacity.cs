using UnityEngine;

public class AnimalCarryingCapacity : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AnimalSkillCarryingCapacitySO carryingCapacitySkill)
        {
            AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(carryingCapacitySkill.carryingCapacity);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
