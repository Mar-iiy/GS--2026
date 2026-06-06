using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class bedInteraction : MonoBehaviour
{
    [SerializeField] GameObject nightPanel;
    public static bool changedLevel;

    private void Start()
    {
        nightPanel.SetActive(false);
        changedLevel = false;
    }

    public void LayDown()
    {
        if (TaskManager.allTasksAreDone && SortTrashTask.taskComplete)
        {
                LevelChange();
        }
        else
        {
            return;
        }
    }

    public void LevelChange()
    {
        Cursor.lockState = CursorLockMode.None;
        nightPanel.SetActive(true);
    }
}
