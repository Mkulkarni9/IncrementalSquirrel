using UnityEngine;

[CreateAssetMenu(fileName = "AddBranchSkillSO", menuName = "Scriptable Objects/AddBranchSkillSO")]
public class TreeAddBranchSO : SkillSO
{
    public GameObject branchPrefab;
    public Vector3 branchLocation;
    public Vector3 branchRotation;
}
