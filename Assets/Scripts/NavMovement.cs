using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMovement : MonoBehaviour
{
    [SerializeField] private NavMeshAgent agent;
    [SerializeField] private float turnSpeed = 0.5f;

    
    
    void Update()
    {
        //Turning
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.up, -turnSpeed);

        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(Vector3.up, turnSpeed);

        }
        
        //NavMovement
        if (Input.GetMouseButtonDown(0))
        {
            
            RaycastHit result;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out result, 50.0f))
            {
                agent.SetDestination(result.point);
            }
        }
    }
}