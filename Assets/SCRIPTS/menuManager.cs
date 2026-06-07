using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class menuManager : MonoBehaviour
{ 

    [Header("Resolution")]
    [SerializeField] Toggle FSToggle;
    private bool isFullScreen;

    void Start()
    {
        isFullScreen = true;
        FSToggle.isOn = Screen.fullScreen;
        FSToggle.onValueChanged.AddListener(ToggleFullscreen);
    }
     
    void ToggleFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    public void QuitGame()
    {
        Application.Quit();
    }
    public void StartGame()
    {
        SceneManager.LoadScene(2);
    }
    public void OptionsMenu()
    {
        SceneManager.LoadScene(1);
    }
    public void MenuGame()
    {
        SceneManager.LoadScene(0);
    }

}
