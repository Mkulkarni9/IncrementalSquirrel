using UnityEngine;
using UnityEngine.UI;

public class UITransitionsManager : MonoBehaviour
{
    [SerializeField] Image skillTreePanel;



    public void DisplaySkillTreePanel()
    {
        skillTreePanel.gameObject.SetActive(true);

    }

        public void HideSkillTreePanel()
    {
        skillTreePanel.gameObject.SetActive(false);
    }

}
