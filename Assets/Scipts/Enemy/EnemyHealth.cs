using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [SerializeField]
    public float health = 100f;
    [SerializeField]
    private float damage = 20f;
    //private GameObject player;
    public void Hit(float damage)
    {
        health -= damage;
        if(health <= 0) {
            Destroy(gameObject);
            //Debug.Log(health);
        }
    }
}


