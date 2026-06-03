using UnityEngine;
using UnityEngine.Rendering;

public class changeRenderByDay : MonoBehaviour
{
    [SerializeField] Volume globalVolume;
    [SerializeField] VolumeProfile[] profiles;

    // Update is called once per frame
    void Update()
    {
        ChangeByLevel();
    }

    void ChangeByLevel()
    {
        if(!changeToComputer.computerIsOn)
        {
            if (dayTaskSystem.dayCount < 3)
            {
                globalVolume.profile = profiles[0];
            }

            if (dayTaskSystem.dayCount > 3 && dayTaskSystem.dayCount < 7)
            {
                globalVolume.profile = profiles[1];
            }

            if (dayTaskSystem.dayCount > 7)
            {
                globalVolume.profile = profiles[2];
            }
        }
    }
}
