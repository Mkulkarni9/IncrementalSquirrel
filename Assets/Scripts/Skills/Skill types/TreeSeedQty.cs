using UnityEngine;

public class TreeSeedQty : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeSeedQtySO seedQtySkill)
        {
            //AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(seedQtySkill.seedQtyIncreaseFactor);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
