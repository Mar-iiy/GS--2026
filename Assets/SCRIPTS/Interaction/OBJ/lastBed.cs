using UnityEngine;

public class lastBed : MonoBehaviour
{
    [SerializeField] GameObject nightPanel;
    public static bool changedLevel;

    private void Start()
    {
        nightPanel.SetActive(false);
    }

    public void LevelChange()
    {
        Cursor.lockState = CursorLockMode.None;
        nightPanel.SetActive(true);
    }
}
