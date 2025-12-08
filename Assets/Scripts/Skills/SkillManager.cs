using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class SkillManager : Singleton<SkillManager>
{
    
    [SerializeField] GameObject skillButtonContainer;

    protected override void Awake()
    {
        base.Awake();
    }


    public void ActivateSkill(SkillSO skillActivated)
    {

        Skill skillInstance = Instantiate(skillActivated.skillPrefab, transform);
        skillInstance.ActivateSkill(skillActivated);
    }


    public void UnlockSkills(SkillSO skillActivated)
    {
        Debug.Log("Unlocking skills: ");
        for (int i = 0; i < skillActivated.skillsUnlocked.Count; i++)
        {
            Button activatedSkill = Instantiate(skillActivated.skillsUnlocked[i], skillButtonContainer.transform);
            Debug.Log(skillActivated.skillsUnlocked[i] + " instantiated");
        }
    }

}
