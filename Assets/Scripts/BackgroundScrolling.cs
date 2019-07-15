using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScrolling : MonoBehaviour
{
    public float scrollSpeed = 1.0f;

    private Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        InvokeRepeating("MoveBG", 0.5f, 0.5f);
    }

    void MoveBG()
    {
        rend.material.mainTextureOffset = new Vector2(rend.material.mainTextureOffset.x + 0.05f, 0.0f);
    }

    /*
    // Update is called once per frame
    void Update()
    {
        // Smooth scrolling
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(Time.time * scrollSpeed, 0);
    }
    */
}
