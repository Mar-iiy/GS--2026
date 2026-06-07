using System;
using UnityEngine;

public class TrashInteract : MonoBehaviour
{
    [SerializeField] private int trashId;

    [Header("AUDIO")]
    [SerializeField] private AudioClip audioLixo;
    [SerializeField] AudioSource audio;

    public void UseTrash()
    {
        if(HoldingItem.isHolding && trashId == HoldingItem.holdingId)
        {
            HoldingItem.isHolding = false;
            HoldingItem.holdingId = 0;
            SortTrashTask.totalTrash++;
        }
    }

    public void PlaySound()
    {
        if (!audio.isPlaying)
        {
            audio.clip = audioLixo;
            audio.Play();
        }
        else
        {
            audio.Stop();
        }
    }
}
