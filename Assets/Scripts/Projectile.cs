using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject damageIndicatorPrefab;

    private void OnCollisionEnter(Collision collision)
    {
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;
        
        
        Destroy(gameObject);
    }
}
