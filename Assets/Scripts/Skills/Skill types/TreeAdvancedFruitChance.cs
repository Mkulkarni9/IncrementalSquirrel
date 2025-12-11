using UnityEngine;

public class TreeAdvancedFruitChance : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeAdvancedFruitSO advancedFruitChanceSkill)
        {
            TreeStatsManager.Instance.UpdateAdvancedFruitChanceBonus(advancedFruitChanceSkill.increasedChanceOfAdvancedFruit);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
