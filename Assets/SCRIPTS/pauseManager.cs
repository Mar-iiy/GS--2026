using UnityEngine;

public class pauseManager : MonoBehaviour
{
    [SerializeField] GameObject pausePanel;
    void Start()
    {
        pausePanel.SetActive(false);
    }

    void Update()
    {
        if(Player.isPaused)
        {
            GamePaused();
        }
    }

    public void GamePaused()
    {
        pausePanel.SetActive(true);
        Cursor.lockState = CursorLockMode.None;
    }

    public void Unpause()
    {
        Player.isPaused = false;
        pausePanel.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
    }
}
