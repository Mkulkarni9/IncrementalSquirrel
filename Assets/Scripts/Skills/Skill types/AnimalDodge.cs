using UnityEngine;

public class AnimalDodge : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AnimalSkillDodgeSO dodgeSkill)
        {
            AnimalStatsManager.Instance.UpdateAnimalDodgeChanceBonus(dodgeSkill.dodgeChance);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
