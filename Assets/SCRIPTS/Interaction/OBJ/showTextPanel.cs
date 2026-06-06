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
    private bool isTalking;
    private int randomThought;
    [SerializeField] private float wait;
    void Start()
    {
        panel.SetActive(false);
        isTalking = false;
    }
    public void ShowPanel()
    {
       if(!isTalking)
       {
            StartCoroutine(timerPanel());
       }   
    }
    IEnumerator timerPanel()
    {
        isTalking = true;
        panel.SetActive(true);
        randomThought = Random.Range(0, thoughtText.Length);
        panelText.text = thoughtText[randomThought].text;
       
        yield return new WaitForSeconds(wait);
        panel.SetActive(false);
        isTalking = false;
    }
}
