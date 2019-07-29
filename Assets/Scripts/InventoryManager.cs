using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public GameObject itemFeedback;

    private int itemCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Item"))
        {
            itemCounter++;
            Debug.Log("Items collected: " + itemCounter);
            // Instantiate item feedback 
            Instantiate(itemFeedback, other.transform.position, other.transform.rotation);
            Destroy(other.gameObject);
        }
    }
}
