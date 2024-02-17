using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingPoints;
    [SerializeField]
    private float range = 100f;

    void Start()
    {

    }
    void Update()
    {
        if(Input.GetButtonDown("Fire1"))
        {
            Shoot();

        }   
    }
    public void Shoot()
    {
        RaycastHit hitInfo;

        if(Physics.Raycast(shootingPoints.transform.position,transform.forward,out hitInfo, range))
        {
            Debug.Log("Hit");
        }
    }
}
