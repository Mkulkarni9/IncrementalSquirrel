using UnityEngine;

public class TreesManager : Singleton<TreesManager>
{
    protected override void Awake()
    {
        base.Awake();
    }

    public void AddTree(GameObject treePrefab, Transform treeLocation)
    {
        GameObject tree = Instantiate(treePrefab);
        tree.transform.position = treeLocation.position;
    }

    public void AddBranch(GameObject branchPrefab, Vector2 branchLocation, Vector3 branchRotation)
    {
        GameObject branch = Instantiate(branchPrefab);
        branchPrefab.transform.position = branchLocation;
        Quaternion eulerAngles = Quaternion.Euler(branchRotation.x, branchRotation.y, branchRotation.z);
        branchPrefab.transform.rotation = eulerAngles;
    }
}
