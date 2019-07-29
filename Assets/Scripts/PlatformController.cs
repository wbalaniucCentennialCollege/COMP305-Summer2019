using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform[] waypoints;
    public float speed = 1.0f;

    private float startTime;
    private float journeyLength;
    private int waypointIndex = 0;
    private int waypointIndexNext = 1;

    void Start()
    {
        startTime = Time.time;
        journeyLength = Vector2.Distance(waypoints[waypointIndex].position, waypoints[waypointIndexNext].position);

        // Sets the initial position of the platform to be at the first waypoint position
        transform.position = waypoints[waypointIndex].position;
    }

    void Update()
    {
        float distCovered = (Time.time - startTime) * speed;
        float fracJourney = distCovered / journeyLength;

        transform.position = Vector2.Lerp(
            waypoints[waypointIndex].position, 
            waypoints[waypointIndexNext].position, 
            fracJourney);

        if(transform.position == waypoints[waypointIndexNext].position)
        {
            // Debug.Log("Reached destination");

            startTime = Time.time;

            // Increment my waypoint index values. 
            waypointIndex = waypointIndexNext;
            waypointIndexNext = (waypointIndexNext + 1) % waypoints.Length;
        }
    }

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
