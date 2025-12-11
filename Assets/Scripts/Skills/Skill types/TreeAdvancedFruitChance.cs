using UnityEngine;

public class TreeAdvancedFruitChance : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeAdvancedFruitSO advancedFruitChanceSkill)
        {
            //AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(advancedFruitChanceSkill.increasedChanceOfAdvancedFruitFactor);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
