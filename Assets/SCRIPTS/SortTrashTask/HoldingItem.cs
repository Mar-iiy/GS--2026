using UnityEngine;

public class HoldingItem : MonoBehaviour
{
    public static bool isHolding;
    public static int holdingId;
    [SerializeField] private int holdingIdInspector;

    [SerializeField] AudioSource audio;
    [SerializeField] private AudioClip audioCollect;

    void Start()
    {
        audio = GetComponent<AudioSource>();
    }

    public void holdTrash()
    {
        if (!isHolding)
        {
            holdingId = holdingIdInspector;
            audio.PlayOneShot(audioCollect);
            GetComponent<Collider>().enabled = false;
            GetComponent<Interactable>().enabled = false;
            Destroy(gameObject, 0.1f);

            isHolding = true;
        }
    }
}
