using UnityEngine;

public class AnimalSpeedSkill : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if(skill is AnimalSkillSpeedSO speedSkill)
        {
            AnimalStatsManager.Instance.UpdateAnimalSpeedBonus(speedSkill.speedIncrementFactor);
            Debug.Log("Skill activated: " + skill.skillName);
        }
        
    }
    
}
