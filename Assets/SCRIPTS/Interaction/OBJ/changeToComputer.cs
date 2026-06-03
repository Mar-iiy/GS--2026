using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeToComputer : MonoBehaviour
{
    [Header("CAMERAS")]
    [SerializeField] private Camera cameraNave;
    [SerializeField] private Camera cameraComputador;

    [Header("UIS")]
    [SerializeField] private GameObject uiNave;
    [SerializeField] private GameObject uiComputador;

    [Header("Spawn Settings")]
    [SerializeField] private float wait;
    [SerializeField] private int spawnAmount = 15;
    [SerializeField] private GameObject objPrefab;

    [SerializeField] public static bool computerIsOn;

    private void Start()
    {
        cameraNave.enabled = true;
        cameraComputador.enabled = false;

        uiNave.SetActive(true);
        uiComputador.SetActive(false);
    }

    private void Update()
    {
        if (computerIsOn && showPoints.pontos == 8)
        {
            computeIsOff();
        }
    }

    public void changeToTask()
    {
        computerIsOn = true;
        showPoints.pontos = 0;
        computerIsRunning();
    }

    public void computerIsRunning()
    {
        if (computerIsOn)
        {
            uiNave.SetActive(false);
            uiComputador.SetActive(true);

            cameraNave.enabled = false;
            cameraComputador.enabled = true;

            StartCoroutine(ShooterGame());
        }
    }

    private void computeIsOff()
    {
        uiNave.SetActive(true);
        uiComputador.SetActive(false);

        cameraComputador.enabled = false;
        cameraNave.enabled = true;

        StopCoroutine(ShooterGame());
    }

    private IEnumerator ShooterGame()
    {
        while (computerIsOn)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Instantiate(objPrefab, new Vector3(Random.Range(-4, 4), Random.Range(-1, 3), 15), Quaternion.identity);
                yield return new WaitForSeconds(wait);
            }
        }
    }
}
