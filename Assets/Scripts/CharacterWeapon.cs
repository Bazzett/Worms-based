using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CharacterWeapon : MonoBehaviour
{
    public LayerMask ignoreMask;
    public GameObject bulletPrefab;
    public Transform barrelPos;
    public float bulletSpeed;

    [Header("Ammo")] 
    [SerializeField] private float magSize;
    [SerializeField] private float bulletsLeft;
    [SerializeField] private Text ammoDisplay;

    private bool readyToShoot = true;
    [SerializeField] private float shootCD;
    void Update()
    {
        RaycastHit hit; 
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePos, out hit, Mathf.Infinity, ignoreMask))
        {
            transform.LookAt(hit.point);
        }


        ammoDisplay.text = bulletsLeft + "/" + magSize;
        Shoot();
    }

    void Shoot()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0) && readyToShoot && bulletsLeft > 0)
        {
            GameObject newProjectile = Instantiate(bulletPrefab, barrelPos.transform.position, transform.rotation);
            newProjectile.GetComponent<Rigidbody>().AddForce(transform.forward * bulletSpeed);

            bulletsLeft--;
            readyToShoot = false;
            
            Invoke(nameof(ResetShot), shootCD);
        }
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

}