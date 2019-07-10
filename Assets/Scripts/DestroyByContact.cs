using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DestroyByContact : MonoBehaviour
{
    public bool restart = false;

    private Transform cameraTrans;
    void Start()
    {
        cameraTrans = Camera.main.transform;
    }

    void Update()
    {
        transform.position = new Vector3(cameraTrans.position.x, transform.position.y, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        Destroy(other.gameObject);

        if(restart)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }
}
