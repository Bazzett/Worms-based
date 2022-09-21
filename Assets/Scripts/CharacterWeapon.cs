using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterWeapon : MonoBehaviour
{
    [SerializeField] private GameObject BulletPrefab;
    [SerializeField] private Transform BarrelPosition;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            GameObject newProjectile = Instantiate(BulletPrefab);
            newProjectile.transform.position = BarrelPosition.position;
            newProjectile.GetComponent<Projectile>().Initialize();
        }
    }
}
