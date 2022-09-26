using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonCamera : MonoBehaviour
{
    public float rotationSpeed;
    public Transform Body;
    public Transform orientation;
    public Transform player;

    [Header("Cameras")]
    public Transform shootingView;
    public CameraStyle currentStyle;
    public GameObject ThirdPersonCam;
    public GameObject ShootingCam;
    public LayerMask ignoreMask;
    
    public enum CameraStyle
    {
        Movement,
        Combat
    }
    
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        Rotation();

        if (Input.GetKeyDown(KeyCode.Mouse1)) SwitchCamera(CameraStyle.Combat);
        if (Input.GetKeyUp(KeyCode.Mouse1)) SwitchCamera(CameraStyle.Movement);
    }

    private void Rotation()
    {
        Vector3 Direction = player.position - new Vector3(transform.position.x, player.position.y, transform.position.z);
        orientation.forward = Direction.normalized;

        RaycastHit hit; 
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePos, out hit, Mathf.Infinity, ignoreMask))
        {
            transform.LookAt(hit.point);
        }
        

        if (currentStyle == CameraStyle.Movement)
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            Vector3 inputDir = orientation.forward * verticalInput + orientation.right * horizontalInput;

            if (inputDir != Vector3.zero)
            {
                Body.forward = Vector3.Slerp(Body.forward, inputDir.normalized, Time.deltaTime * rotationSpeed);
            }
        }
        else if (currentStyle == CameraStyle.Combat)
        {
            Vector3 shootDir = shootingView.position - new Vector3(transform.position.x, shootingView.position.y, transform.position.z);
            orientation.forward = shootDir.normalized;

            Body.forward = shootDir.normalized;
        }
    }
    
    private void SwitchCamera(CameraStyle newStyle)
    {
        ShootingCam.SetActive(false);
        ThirdPersonCam.SetActive(false);
        
        if (newStyle == CameraStyle.Movement) ThirdPersonCam.SetActive(true);
        if (newStyle == CameraStyle.Combat) ShootingCam.SetActive(true);

        currentStyle = CameraStyle.Movement;
    }
}
