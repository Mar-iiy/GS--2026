using System.Collections;
using TMPro;
using Unity.VisualScripting;
using UnityEditor.Rendering;
using UnityEngine;

public class PointShoot : MonoBehaviour
{
    [SerializeField] private GameObject aim;
    [SerializeField] private Transform laserPoint;
    [SerializeField] private GameObject bullet;
    
    [SerializeField] private Camera mainCam;
    
    private Vector3 target;
    [SerializeField] private float distanceFromCamera = 10f;
    [SerializeField] private Transform resetPosition;

    private bool bulletFired;

    void Update()
    {
        if (changeToComputer.computerIsOn)
        {
            target = Input.mousePosition;
            target.z = distanceFromCamera;
            target = mainCam.ScreenToWorldPoint(target);
            aim.transform.position = target;
            ShootInput();
            Shoot();
        }

        else
        {
            aim.transform.position = resetPosition.position;
        }
    }
       
    void ShootInput()
    {
        if(changeToComputer.computerIsOn)
        {
           if (Input.GetMouseButtonDown(0) && !bulletFired)
           { 
             bulletFired = true;
           }
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
