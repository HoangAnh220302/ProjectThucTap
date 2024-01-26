using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class test : MonoBehaviour
{
    [SerializeField] GameObject[] positions = new GameObject[5];
    [SerializeField] float speed = 5;

    void Update()
    {
        move1();
    }
    public void A()
    {
        if(Input.GetKeyDown(KeyCode.A))
        {
            Debug.Log("A");
            Debug.Log(positions[0].transform.position);
        }
        else if(Input.GetKeyDown(KeyCode.B))
        {
            Debug.Log("B");
        }
        else if (Input.GetKeyDown(KeyCode.C))
        {
            Debug.Log("C");
        }
    }
    public void move1()
    {
        /*
        for(int i = 0; i < positions.Length; i++) {
            transform.position = Vector3.MoveTowards(transform.position, positions[i].transform.position, speed * Time.deltaTime);
            if (Vector3.Distance(transform.position, positions[i].transform.position) < 0.001f)
            {
                transform.position = Vector3.MoveTowards(transform.position, positions[i + 1].transform.position, speed * Time.deltaTime);
            }
        }
        
        if (Vector3.Distance(transform.position, positions[4].transform.position) < 0.001f)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[1].transform.position, speed * Time.deltaTime);
        }
        */
        transform.position = Vector3.MoveTowards(transform.position, positions[0].transform.position, speed * Time.deltaTime);
        if (Vector3.Distance(transform.position, positions[0].transform.position) < 1f)
        {
            transform.position = Vector3.MoveTowards(transform.position, positions[1].transform.position, speed * Time.deltaTime);
        }
    }
}

