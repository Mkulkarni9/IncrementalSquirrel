using UnityEngine;

public class BootArtefact : Artefact
{
    public override void TriggerArtefact(ArtefactSO artefactAdded)
    {
        if(artefactAdded is BootArtefactSO bootArtefact)
        {
            AnimalStatsManager.Instance.UpdateAnimalSpeedBonus(bootArtefact.speedModifier);
        }
    }
}
