using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControllerWithBuffer : MonoBehaviour
{
    private Transform playerPos;
    [Range(1.0f, 10.0f)]
    public float cameraSafeOffsetSizeX = 5.0f;
    [Range(1.0f, 10.0f)]
    public float cameraSafeOffsetSizeY = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindGameObjectWithTag("Player").transform;

        if (playerPos == null)
        {
            Debug.Log("Cannot find the player");
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (playerPos == null)
            return;

        // Check against X-axis thresholds
        if (playerPos.position.x < transform.position.x - (0.5f * cameraSafeOffsetSizeX))
        {
            transform.position = new Vector3(
                playerPos.position.x + (0.5f * cameraSafeOffsetSizeX), 
                transform.position.y, 
                transform.position.z);
        }
        else if (playerPos.position.x > transform.position.x + (0.5f * cameraSafeOffsetSizeX))
        {
            transform.position = new Vector3(
                playerPos.position.x - (0.5f * cameraSafeOffsetSizeX),
                transform.position.y,
                transform.position.z);
        }


        if (playerPos.position.y < transform.position.y - (0.5f * cameraSafeOffsetSizeY))
        {
            transform.position = new Vector3(
                transform.position.x,
                playerPos.position.y + (0.5f * cameraSafeOffsetSizeY),
                transform.position.z);
        }
        else if (playerPos.position.y > transform.position.y + (0.5f * cameraSafeOffsetSizeY))
        {
            transform.position = new Vector3(
                transform.position.x,
                playerPos.position.y - (0.5f * cameraSafeOffsetSizeY),
                transform.position.z);
        }
    }

    void OnDrawGizmos()
    {
        /*
        // Setup my thresholds
        Vector3 thresholdL = new Vector3(
            transform.position.x - cameraSafeOffsetSizeX,
            transform.position.y,
            transform.position.z);

        Vector3 thresholdR = new Vector3(
            transform.position.x + cameraSafeOffsetSizeX,
            transform.position.y,
            transform.position.z);

        Vector3 thresholdUP = new Vector3(
            transform.position.x,
            transform.position.y + cameraSafeOffsetSizeY,
            transform.position.z);

        Vector3 thresholdDOWN = new Vector3(
            transform.position.x,
            transform.position.y - cameraSafeOffsetSizeY,
            transform.position.z);
            */

        Gizmos.color = Color.magenta;
        Gizmos.DrawWireCube(transform.position, new Vector3(
            cameraSafeOffsetSizeX, cameraSafeOffsetSizeY, 0.0f));
    }
}
