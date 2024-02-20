using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField]
    private GameObject shootingPoints;
    [SerializeField]
    private float range = 100f;
    [SerializeField]
    private float damage = 20f;

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
            //Debug.Log(shootingPoints.transform.position);
            EnemyHealth enemyHealth = hitInfo.transform.GetComponent<EnemyHealth>();
            if(enemyHealth != null)
            {
                enemyHealth.Hit(damage);
                Debug.Log(enemyHealth.health);
            }
        }
    }
}
