using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
public class SortTrashTask : MonoBehaviour
{
    [Header("SHOW TASK")]
    [SerializeField] private TextMeshProUGUI showTask;
    [SerializeField] private TextAsset[] taskName;

    [Header("SHOW CHECK")]
    [SerializeField] private Image taskImage;
    [SerializeField] private Sprite[] check;

    [SerializeField] Image inventory;
    [SerializeField] private Sprite[] sprites;

    public static bool taskComplete;
    public static int totalTrash;
    void Start()
    {
        HoldingItem.isHolding = false;
        totalTrash = 0;
        taskComplete = false;
    }

    void Update()
    {
        if(!HoldingItem.isHolding)
        {
            inventory.sprite = sprites[0];
        }
        else
        {
            if(HoldingItem.holdingId == 1)
            {
                inventory.sprite = sprites[1];
            }
            if (HoldingItem.holdingId == 2)
            {
                inventory.sprite = sprites[2];
            }
            if (HoldingItem.holdingId == 3)
            {
                inventory.sprite = sprites[3];
            }
        }

        if(totalTrash == 10)
        {
            taskComplete = true;
        }

        showTaskUI();
    }

    private void showTaskUI()
    {
        string textToShow = taskComplete ? taskName[0].text : taskName[1].text;
        showTask.text = textToShow;

        taskImage.sprite = taskComplete ? check[0] : check[1];
    }

}
