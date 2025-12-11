using UnityEngine;

public class TreeLightening : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeLighteningSO lighteningSkill)
        {
            //AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(lighteningSkill.lighteningPrefab, lighteningSkill.lighteningChance);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
