using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInteract : MonoBehaviour
{
    private Camera camera;
    [SerializeField] private float distance = 3.0f;
    [SerializeField] private LayerMask mask;
    public PlayerUI playerUI;

    private void Start()
    {
        camera = GetComponent<PlayerLook>().camera;
        playerUI = GetComponent<PlayerUI>();
    }
    private void Update()
    {
        playerUI.UpdateText(string.Empty);
        Ray ray = new Ray(camera.transform.position,camera.transform.forward);
        Debug.DrawRay(ray.origin,ray.direction * distance);
        RaycastHit hitInfo;
        if(Physics.Raycast(ray, out hitInfo, distance, mask))
        {
            if(hitInfo.collider.GetComponent<Interactable>() != null)
            {
                playerUI.UpdateText(hitInfo.collider.GetComponent<Interactable>().promtMessage);
            }
        }
    }
}
