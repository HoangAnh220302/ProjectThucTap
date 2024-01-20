using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLook : MonoBehaviour
{
    public Camera camera;

    public float xRotation = 0;

    public float xSensitive = 10f;
    public float ySensitive = 10f;

    public void Proccessed_Look(Vector2 input)
    {
        float mouseX = input.x;
        float mouseY = input.y;

        xRotation -= (mouseY * Time.deltaTime) * ySensitive;
        xRotation = Mathf.Clamp(xRotation, -80, 80);

        camera.transform.localRotation = Quaternion.Euler(xRotation,0,0);
        transform.Rotate(Vector3.up *(mouseX * Time.deltaTime)*xSensitive);
    }
}

