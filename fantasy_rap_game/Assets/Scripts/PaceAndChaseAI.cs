/*
 * Name: Jackson Miller
 * Date: 10/5/23
 * Desc: Simple AI that can pace and chase the player within a range.
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PaceAndChaseAI : MonoBehaviour
{
    public Vector3[] waypoints;
    public float closeEnough = 0.3f;
    public float paceSpeed = 3;
    public float chaseSpeed = 5;
    public float chaseDistDefault = 3;
    public float chaseDistIncrease = 2;
    private float chaseDist;
    public GameObject chaseTarget;
    private int currentWaypoint = 0;
    private Rigidbody2D myRB;
    // Start is called before the first frame update
    void Start()
    {
        myRB = GetComponent<Rigidbody2D>();
        chaseDist = chaseDistDefault;
    }

    // Update is called once per physics frame
    void FixedUpdate()
    {
        if(chaseTarget != null)
        {
            // Check the distance to chaseTarget
            Vector3 chaseVector = chaseTarget.transform.position - transform.position;
            if (chaseVector.sqrMagnitude < chaseDist * chaseDist)
            {
                Chase(chaseVector.normalized);
            }
            else Pace();
        }
        else Pace();
    }

    void Pace()
    {
        chaseDist = chaseDistDefault;
        // If we are close enough, change to new waypoint.
        if(waypoints.Length == 0) return;
        if ((waypoints[currentWaypoint] - transform.position).sqrMagnitude < closeEnough * closeEnough)
        {
            currentWaypoint++;
            if(currentWaypoint >= waypoints.Length)
            {
                currentWaypoint = 0;
            }
        }
        // Move towards current waypoint.
        myRB.velocity = (waypoints[currentWaypoint] - transform.position).normalized * paceSpeed;
    }

    void Chase(Vector3 direction)
    {
        chaseDist = chaseDistDefault + chaseDistIncrease;
        myRB.velocity = direction * chaseSpeed;
    }
}
