
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Keypad : Interactable
{
    [SerializeField]
    private GameObject door;
    private bool doorOpen;
    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public override void Interact()
    {
        doorOpen = false;
        Destroy(door);
        //base.Interact();
        Debug.Log("Interacted with " + gameObject.name);
    }
}
