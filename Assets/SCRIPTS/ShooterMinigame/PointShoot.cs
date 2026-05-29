using Unity.VisualScripting;
using System.Collections;
using UnityEngine;
using TMPro;

public class PointShoot : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private GameObject bullet;



    private Camera mainCam;
    private Vector3 target;
    private bool bulletFired;
    void Start()
    {
        mainCam = Camera.main;
    }
    void Update()
    {
        target = Input.mousePosition;
        target.z = mainCam.WorldToScreenPoint(aim.transform.position).z;
        target = mainCam.ScreenToWorldPoint(target);
        aim.transform.position = target;
        ShootInput();
        Shoot();
    }

    void ShootInput()
    {
        if (Input.GetMouseButtonDown(0) && !bulletFired)
        { 
            bulletFired = true;
        }
    }

    void Shoot()
    {
        if(bulletFired)
        {
            Instantiate(bullet, laserPoint.position, Quaternion.identity);
            bulletFired= false;
        }            
    }  
}
