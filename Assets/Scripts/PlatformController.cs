using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    void OnCollisionStay2D(Collision2D other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = transform;
        }
    }

    void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            other.transform.parent = null;
        }
    }
}
