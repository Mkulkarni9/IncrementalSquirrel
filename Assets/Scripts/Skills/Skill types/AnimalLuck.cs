using UnityEngine;

public class AnimalLuck : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AnimalSkillLuckSO luckSkill)
        {
            AnimalStatsManager.Instance.UpdateAnimalLuckBonus(luckSkill.luck);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
