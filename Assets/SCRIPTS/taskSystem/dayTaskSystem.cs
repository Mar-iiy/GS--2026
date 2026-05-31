using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dayTaskSystem : MonoBehaviour
{
    [Header("SHOW IN-GAME DAY")]
    [SerializeField] private TextMeshProUGUI showDay;
    [SerializeField] private TextAsset[] dayText;
    [SerializeField] public static int dayCount;

    [Header("SHOW TASK")]
    [SerializeField] private TextMeshProUGUI[] showTask;
    [SerializeField] private TextAsset[] taskName;
    [SerializeField] private int taskNumber;

    [Header("CHECKMARK IMG OBJ")]
    [SerializeField] private Image[] taskCheck;
    [SerializeField] private Sprite[] taskCheckImage;

      
    private bool[] taskDone;
    public static bool allTaskDone;

    void Start()
    {
        //taskCheck[].sprite = taskCheckImage[0];
        allTaskDone = false;
    }

    // Update is called once per frame
    void Update()
    {
        ChangeDay();
    }

   void TaskDoneCheck()
   {
           
   }

   void ShowTask()
   {
        showTask[taskNumber].text = taskName[taskNumber].text;
   }

   void ChangeDay()
   {
        showDay.text = dayText[dayCount].text;
   }
}
