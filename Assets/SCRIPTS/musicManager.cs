using UnityEngine;
using UnityEngine.SceneManagement;

public class musicManager : MonoBehaviour
{
    public static musicManager Instance;

    public AudioSource audioSource;

    public AudioClip menuMusic;
    public AudioClip happyLevelMusic;
    public AudioClip sadLevelMusic;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
            SceneManager.sceneLoaded += OnSceneLoaded;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Start()
    {
        PlayMusic(menuMusic);
    }
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        switch (scene.name)
        {
            case "MENU":
            case "OPTIONS":
                PlayMusic(menuMusic);
                break;

            case "LEVEL01":
            case "LEVEL02":
            case "LEVEL03":
                PlayMusic(happyLevelMusic);
                break;

            case "LEVEL04":
            case "LEVEL05":
            case "LEVEL06":
            case "LEVEL07":
                PlayMusic(sadLevelMusic);
                break;
        }
    }

    void PlayMusic(AudioClip clip)
    {
        if (audioSource.clip == clip) return;

        audioSource.clip = clip;
        audioSource.Play();
    }

    private void OnDestroy()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }
}
