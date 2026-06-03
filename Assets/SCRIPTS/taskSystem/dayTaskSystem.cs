using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class dayTaskSystem : MonoBehaviour
{
    [Header("SHOW IN-GAME DAY")]
    [SerializeField] private TextMeshProUGUI showDay;
    [SerializeField] private TextAsset[] dayText;
     public static int dayCount;

    // Update is called once per frame
    void Update()
    {
        ChangeDay();
    }
    void ChangeDay()
    {
        showDay.text = dayCount.ToString();
    }
}
