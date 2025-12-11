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
}
