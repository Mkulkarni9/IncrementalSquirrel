using UnityEngine;

public class AnimalSlowdownSpeedTimeReduction : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AnimalSlowdownSkillTimeReductionSO slowdownSkillTimeReductionSkill)
        {
            AnimalStatsManager.Instance.UpdateSlowdownSpeedTimeReductionBonus(slowdownSkillTimeReductionSkill.timeReduction);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
