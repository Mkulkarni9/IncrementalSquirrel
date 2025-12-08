using UnityEngine;

public class AnimalRestTime : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AnimalSkillRestTimeSO restTimeSkill)
        {
            AnimalStatsManager.Instance.UpdateAnimalRestTimeBonus(restTimeSkill.restTime);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
