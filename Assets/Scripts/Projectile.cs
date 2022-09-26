using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public GameObject damageIndicatorPrefab;
    public float damage = 10f;
    
    private void OnCollisionEnter(Collision collision)
    {
        GameObject damageIndicator = Instantiate(damageIndicatorPrefab);
        damageIndicator.transform.position = collision.GetContact(0).point;

        Destroy(gameObject);
        
        Target target = transform.GetComponent<Target>();

        if (target != null)
        {
            target.TakeDamage(damage);
        }
    }
    
    
    
}
