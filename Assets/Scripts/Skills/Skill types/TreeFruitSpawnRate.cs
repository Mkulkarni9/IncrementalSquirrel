using UnityEngine;

public class TreeFruitSpawnRate : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeFruitSpawnRateSO fruitSpawnRateSkill)
        {
            TreeStatsManager.Instance.UpdateFruitSpawnRateBonus(fruitSpawnRateSkill.fruitSpawnRateInterval);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
