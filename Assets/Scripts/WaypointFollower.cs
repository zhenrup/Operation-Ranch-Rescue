using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints; //waypoint is stored as an array so that an object can have a variable number of waypoints
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;
    private SpriteRenderer sprite;
    private bool xvalue = false;

    private void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {   
        //if the object reaches the current waypoint position
        if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
        {   
            //then
            currentWaypointIndex++; //increase waypoint index by 1
            sprite.flipX = !xvalue; //flip the objects X value
            xvalue = !xvalue; //store the current X value
            if (currentWaypointIndex >= waypoints.Length) //once we reach the last waypoint in the cycle,
            {
                currentWaypointIndex = 0; //reset the waypoints index back to the beginning
            }
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);        
    }
}
