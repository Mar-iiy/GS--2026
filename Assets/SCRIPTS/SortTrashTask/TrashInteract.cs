using System;
using UnityEngine;

public class TrashInteract : MonoBehaviour
{
    [SerializeField] private int trashId;

    public void UseTrash()
    {
        if(HoldingItem.isHolding && trashId == HoldingItem.holdingId)
        {
            HoldingItem.isHolding = false;
            HoldingItem.holdingId = 0;
            SortTrashTask.totalTrash++;
        }
    }
}
