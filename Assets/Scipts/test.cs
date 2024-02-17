using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class test : MonoBehaviour
{
    public float customTime;
    public Transform[] location = new Transform[5];
    public float speed = 5;
    void Start()
    {
        
    }
    void Update()
    {
        
    }
    public void moveTime()
    {
        transform.position = Vector3.MoveTowards(transform.position, location[0].position, speed * Time.deltaTime);
        Debug.Log(Vector3.Distance(transform.position, location[0].position));
        if (Vector3.Distance(transform.position, location[0].position) < 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, location[0].position, speed * Time.deltaTime);
        }
    }
}
