using UnityEngine;

public class TaskManager : MonoBehaviour
{
    public TaskItem[] allTasks;
    public static bool allTasksAreDone = false;

    void Update()
    {
        if (!allTasksAreDone)
        {
            CheckProgress();
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

