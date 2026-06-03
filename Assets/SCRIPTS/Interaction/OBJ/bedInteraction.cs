using System.Collections;
using UnityEngine;

public class bedInteraction : MonoBehaviour
{
    [SerializeField] GameObject nightPanel;

    public static bool changedLevel;

    private void Start()
    {
        nightPanel.SetActive(false);
    }
    public void LayDown()
    {
        if(TaskManager.allTasksAreDone)
        {
            dayTaskSystem.dayCount++;
        }
        else
        {
            return;
        }
    }

    public void LevelChange()
    {
        nightPanel.SetActive(true);
    }
}
