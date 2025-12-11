using UnityEngine;

public class TreeFoodQty : Skill
{
    public override void ActivateSkill(SkillSO skill)
    {
        if (skill is TreeFoodQtySO foodQtySkill)
        {
            FruitStatsManager.Instance.UpdateFoodQtyBonus(foodQtySkill.foodQtyIncreaseFactor);
            Debug.Log("Skill activated: " + skill.skillName);
        }
    }
}
