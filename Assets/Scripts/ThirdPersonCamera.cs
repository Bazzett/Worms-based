using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    [Header("References")] 
    public Transform orientation;
    public Transform player;
    public Transform playerObj;
    public Rigidbody rb;

    public float rotationSpeed;
    
    

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    private void Update()
    {

        float Horizontal = Input.GetAxis("Horizontal");
        float Veritcal = Input.GetAxis("Vertical");
        Vector3 Direction = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.position = Direction.normalized;

        Vector3 inputDir = orientation.forward * Veritcal + orientation.right * Horizontal;

        if (inputDir != Vector3.zero)
        {
            playerObj.forward = Vector3.Slerp(playerObj.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
        }
    }
}
