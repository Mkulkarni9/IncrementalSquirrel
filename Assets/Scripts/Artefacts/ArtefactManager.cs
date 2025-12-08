using System.Collections.Generic;
using UnityEngine;

public class ArtefactManager : Singleton<ArtefactManager>
{
    [SerializeField] List<ArtefactSO> artefactsList;

    public List<ArtefactSO> ArtefactsList { get; private set; }
    public List<ArtefactSO> ArtefactsCollectedList { get; private set; }


    protected override void Awake()
    {
        base.Awake();
    }

    private void Start()
    {
        ArtefactsList = artefactsList;
    }


    public void TriggerArtefacts(ArtefactSO artefactAdded)
    {
        Debug.Log("Triggering artefact");
        GameObject artefact = Instantiate(artefactAdded.artefactGO, this.transform);
        artefact.GetComponent<Artefact>().TriggerArtefact(artefactAdded);

        UpdateArtefactsCollectedList(artefactAdded);
    }
    public void UpdateArtefactsCollectedList(ArtefactSO artefactAdded)
    {
        ArtefactsCollectedList.Add(artefactAdded);
    }


}
