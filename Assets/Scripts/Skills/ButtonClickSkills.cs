using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonClickSkills : MonoBehaviour, IPointerClickHandler
{

    [SerializeField] SkillSO skillSO;


    

    public void OnPointerClick(PointerEventData eventData)
    {
        if (this.GetComponent<Button>().interactable)
        {
            SkillManager.Instance.ActivateSkill(skillSO);
            SkillManager.Instance.UnlockSkills(skillSO);

            this.GetComponent<Button>().interactable = false;
        }
    }
}
