using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeController : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //Debug.Log("Toucing the player");
            other.GetComponent<PlayerController>().Death();
        }
    }
}
