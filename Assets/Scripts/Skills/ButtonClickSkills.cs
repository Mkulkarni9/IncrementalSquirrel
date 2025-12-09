using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickSkills : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] List<SkillSO> skillSO;


    int currentSkillLevelIndex;

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable)
        {
            SkillManager.Instance.ActivateSkill(skillSO[currentSkillLevelIndex]);
            SkillManager.Instance.UnlockSkills(skillSO[currentSkillLevelIndex]);

            //Debug.Log("Skill: " + skillSO[currentSkillLevelIndex].skillName + " activated with current skill level index: " + currentSkillLevelIndex);

            if (currentSkillLevelIndex == skillSO.Count-1)
            {
                this.GetComponent<Button>().interactable = false;
            }
            else
            {
                
                currentSkillLevelIndex++;
            }


                

        }
    }
}
