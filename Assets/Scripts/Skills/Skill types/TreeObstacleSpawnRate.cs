using UnityEngine;

public class TreeObstacleSpawnRate : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeObstacleSpawnRateSO obstacleSpawnRateSkill)
        {
            TreeStatsManager.Instance.UpdateObstacleSpawnRateBonus(obstacleSpawnRateSkill.obstacleSpawnRateInterval);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
