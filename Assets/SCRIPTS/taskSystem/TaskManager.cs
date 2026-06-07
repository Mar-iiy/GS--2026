using UnityEngine;
using TMPro;

public class TaskManager : MonoBehaviour
{
    public TaskItem[] allTasks;
    public static bool allTasksAreDone;

    [SerializeField] GameObject sleepAlert;
    [SerializeField] private bool allTask;

    private void Start()
    {
        sleepAlert.SetActive(false);
        allTasksAreDone = false;
    }

    void Update()
    {
        allTask = allTasksAreDone;

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

