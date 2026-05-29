using System;
using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;

public class showTextPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextAsset thoughtText;
    [SerializeField] private TextMeshProUGUI panelText;

    [SerializeField] private float wait;
    void Start()
    {
        panel.SetActive(false);
    }
    public void ShowPanel()
    {
        StartCoroutine(timerPanel());
    }
    IEnumerator timerPanel()
    {
        panel.SetActive(true);
        panelText.text = thoughtText.text;
        yield return new WaitForSeconds(wait);
        panel.SetActive(false);
    }
}
