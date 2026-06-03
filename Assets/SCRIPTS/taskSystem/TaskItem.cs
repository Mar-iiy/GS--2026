using TMPro;
using UnityEngine.UI;
using UnityEngine;

public class TaskItem : MonoBehaviour
{
    [Header("SHOW TASK")]
    [SerializeField] private TextMeshProUGUI showTask;
    [SerializeField] private TextAsset[] taskName;

    [Header("SHOW CHECK")]
    [SerializeField] private Image taskImage;                 
    [SerializeField] private Sprite[] sprites;

    // State of this specific task
    public bool isCompleted = false;

    private void Start()
    {
        isCompleted = false;
    }

    private void Update()
    {
        showTaskUI();
    }

    public void CompleteTask()
    {
        isCompleted = true;
    }

    private void showTaskUI()
    {
        string textToShow = isCompleted ? taskName[0].text : taskName[1].text;
        showTask.text = textToShow;

        taskImage.sprite = isCompleted ? sprites[0] : sprites[1];
    }
}
