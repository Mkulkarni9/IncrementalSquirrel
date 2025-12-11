using UnityEngine;

public class TreeFruitBlossom : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeFruitBlossomSO fruitBlossomSkill)
        {
            TreeStatsManager.Instance.StartFruitBlossom(fruitBlossomSkill.fruitBlossomInterval, fruitBlossomSkill.fruitBlossomChance, fruitBlossomSkill.fruitBlossomNumberOfFruits);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
