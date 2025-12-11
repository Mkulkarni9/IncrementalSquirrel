using UnityEngine;

public class TreeLifeEssesnceQty : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeLifeEssenceQtySo lifeEssenceQtySkill)
        {
            FruitStatsManager.Instance.UpdateLifeEssenceQtyBonus(lifeEssenceQtySkill.lifeEssenceQtyIncreaseFactor);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
