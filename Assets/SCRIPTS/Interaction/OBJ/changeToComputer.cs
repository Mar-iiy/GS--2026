using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeToComputer : MonoBehaviour
{
    [Header("CAMERAS")]
    [SerializeField] private Camera cameraNave;
    [SerializeField] private Camera cameraComputador;

    [Header("UI")]
    [SerializeField] private GameObject uiNave;

    [Header("Spawn Settings")]
    [SerializeField] private float wait;
    [SerializeField] private GameObject objPrefab;

    [Header("AUDIO")]
    [SerializeField] private AudioClip audioVent;
    [SerializeField] AudioSource audio;

    [SerializeField] public static bool computerIsOn;
    [SerializeField] public static bool computerUsed;

    private void Start()
    {
        computerUsed = false;

        cameraNave.enabled = true;
        cameraComputador.enabled = false;

        uiNave.SetActive(true);
    }

    private void Update()
    {
        if (computerIsOn && showPoints.pontos == 10)
        {
            computerUsed = true;
            computeIsOff();
        }
    }

    public void changeToTask()
    {
       if(!computerUsed)
       {
            computerIsOn = true;
            showPoints.pontos = 0;
            computerIsRunning();
       }
       else
       {
            return;
       }
    }

    public void computerIsRunning()
    {
        if (computerIsOn)
        {
            Cursor.lockState = CursorLockMode.None;

            uiNave.SetActive(false);

            cameraNave.enabled = false;
            cameraComputador.enabled = true;

            StartCoroutine(ShooterGame());
        }
    }

    private void computeIsOff()
    {
        computerIsOn = false;

        Cursor.lockState = CursorLockMode.Locked;

        uiNave.SetActive(true);

        cameraComputador.enabled = false;
        cameraNave.enabled = true;

        StopCoroutine(ShooterGame());
        PlaySound();
    }

    public void PlaySound()
    {
        if (!GetComponent<AudioSource>().isPlaying)
        {
            GetComponent<AudioSource>().clip = audioVent;
            GetComponent<AudioSource>().Play();
        }
        else
        {
            GetComponent<AudioSource>().Stop();
        }
    }

    private IEnumerator ShooterGame()
    {
        while (computerIsOn)
        {
                Instantiate(objPrefab, new Vector3(Random.Range(-8, 8), Random.Range(-3, 5), 15), Quaternion.identity);
                yield return new WaitForSeconds(wait);
        }
    }
}
