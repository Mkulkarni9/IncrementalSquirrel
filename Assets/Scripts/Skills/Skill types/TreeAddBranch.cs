using UnityEngine;

public class TreeAddBranch : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeAddBranchSO addBranchSkill)
        {
            TreesManager.Instance.AddBranch(addBranchSkill.branchPrefab, addBranchSkill.branchLocation, addBranchSkill.branchRotation);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
