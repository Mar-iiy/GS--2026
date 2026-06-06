using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TaskItem[] allTasks;
    public static bool allTasksAreDone = false;

    [SerializeField] GameObject sleepAlert;

    private void Start()
    {
        sleepAlert.SetActive(false);
    }

    void Update()
    {
        if (!allTasksAreDone)
        {
            CheckProgress();
        }

        else if (allTasksAreDone && SortTrashTask.taskComplete)
        {
            sleepAlert.SetActive(true);
        }
    }

    void CheckProgress()
    {
        foreach (TaskItem task in allTasks)
        {
            if (!task.isCompleted)
            {
                return; 
            }
        }

        allTasksAreDone = true;
    }
}

