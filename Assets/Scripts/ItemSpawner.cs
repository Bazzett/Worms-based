using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemSpawner : MonoBehaviour
{
    [SerializeField] private GameObject spawnItem; 
        
    private bool readyToSpawn = false;
    [SerializeField] private float spawnCD;
    
    private GameObject item;
    
    void Update()
    {
        if (GameObject.Find(spawnItem.ToString()) != null)
        {
            item = GameObject.Find(spawnItem.ToString()).gameObject;
        }
            
        if (readyToSpawn && item == null)
        {
            SpawnDesiredItem();
        }
    
        if (item == null && !IsInvoking())
        {
            Invoke(nameof(ResetSpawn), spawnCD);
        }
    }
    
    private void SpawnDesiredItem()
    {
        item = Instantiate(spawnItem, transform.position, Quaternion.identity);
        readyToSpawn = false;
    }
    
    private void ResetSpawn()
    {
        readyToSpawn = true;
    }
}
