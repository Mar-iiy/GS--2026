using System;
using System.Collections;
using TMPro;
using UnityEngine;
using Random = UnityEngine.Random;

public class showTextPanel : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private TextAsset[] thoughtText;
    [SerializeField] private TextMeshProUGUI panelText;

    private int randomThought;
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
        randomThought = Random.Range(0, thoughtText.Length);
        panelText.text = thoughtText[randomThought].text;
       
        yield return new WaitForSeconds(wait);
        panel.SetActive(false);
    }
}
