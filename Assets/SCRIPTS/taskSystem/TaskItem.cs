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

    [Header("AUDIO")]
    [SerializeField] private AudioClip audioEfeito;
    [SerializeField] AudioSource audio;

    public bool isCompleted = false;

    private void Start()
    {
       audio = GetComponent<AudioSource>();
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

    public void PlaySound()
    {
        if (!audio.isPlaying)
        {
            audio.clip = audioEfeito;
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }

    private void showTaskUI()
    {
        string textToShow = isCompleted ? taskName[0].text : taskName[1].text;
        showTask.text = textToShow;

        taskImage.sprite = isCompleted ? sprites[0] : sprites[1];
    }
}
