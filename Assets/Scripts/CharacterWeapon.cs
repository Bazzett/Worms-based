
using UnityEngine;
using UnityEngine.UI;


public class CharacterWeapon : MonoBehaviour
{
    
    public LayerMask ignoreMask;
    public GameObject bulletPrefab;
    public Transform barrelPos;
    public float bulletSpeed;

    [Header("Ammo")] 
    [SerializeField] public float magSize;
    [SerializeField] public float bulletsLeft;
    [SerializeField] private Text ammoDisplay;
    
    private bool readyToShoot = true;
    [SerializeField] private float shootCD;

    private void Awake()
    {
        bulletsLeft = magSize;
    }

    void Update()
    {
        RaycastHit hit; 
        Ray mousePos = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(mousePos, out hit, Mathf.Infinity, ignoreMask))
        {
            transform.LookAt(hit.point);
        }

        if (bulletsLeft > magSize)
        {
            Reload();
        }
        
        ammoDisplay.text = "Bullets left " + bulletsLeft + "/" + magSize;
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

    public void Reload()
    {
        bulletsLeft = magSize;
    }
    
    
    private void ResetShot()
    {
        readyToShoot = true;
    }

}