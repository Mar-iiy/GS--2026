using UnityEngine;
using DG.Tweening;

public class colorBox : MonoBehaviour
{
    private Material material;
    void Start()
    {
        material = GetComponent<Renderer>().material;
    }
    public void colorFlash()
    {
        material.DOColor(Color.red, 2f);
    }


}
