using UnityEngine;

public class TreeAddBranch : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeAddBranchSO addBranchSkill)
        {
            //AnimalStatsManager.Instance.UpdateAnimalCarryingCapacityBonus(addBranchSkill.branchPrefab);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
