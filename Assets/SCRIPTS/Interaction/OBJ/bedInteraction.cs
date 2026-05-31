using UnityEngine;

public class bedInteraction : MonoBehaviour
{
    void layDown()
    {
        if(dayTaskSystem.allTaskDone)
        {
            dayTaskSystem.dayCount++;
        }
        else
        {
            return;
        }
    }
}
