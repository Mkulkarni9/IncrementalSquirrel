using UnityEngine;

public class AddTreeSkill : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is AddTreeSkillSO addTreeSkill)
        {
            TreesManager.Instance.AddTree(addTreeSkill.treePrefab, addTreeSkill.treeLocation);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
