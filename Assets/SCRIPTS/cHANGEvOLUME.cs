using UnityEngine;
using UnityEngine.Audio;

public class cHANGEvOLUME : MonoBehaviour
{
    public AudioMixer group;
    public string floatParameter = "";
   
    public void OnChangeVolume(float f)
    {
        group.SetFloat(floatParameter, f);
    }
}
