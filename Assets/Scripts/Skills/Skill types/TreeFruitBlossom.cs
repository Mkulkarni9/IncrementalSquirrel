using UnityEngine;

public class TreeFruitBlossom : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeFruitBlossomSO fruitBlossomSkill)
        {
            //AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(fruitBlossomSkill.fruitBlossomChance);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
