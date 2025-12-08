using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillSO : ScriptableObject
{
    public string skillName;
    public string skillDescription;
    public float seedCost;
    public float essenceCost;
    public List<Button> skillsUnlocked;

    public Skill skillPrefab;
}
