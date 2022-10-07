using UnityEngine;

public class Projectile : MonoBehaviour
{
 
    [SerializeField] private int bulletDamage;
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<Target>().TakeDamage(bulletDamage);
            Destroy(gameObject);
        }
        else if (collision.gameObject.tag != "Player")
        {
            Destroy(gameObject);
        }
        
        
    }
}
