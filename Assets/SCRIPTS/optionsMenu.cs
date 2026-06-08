using UnityEngine;
using UnityEngine.UI;

public class optionsMenu : MonoBehaviour
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
}
