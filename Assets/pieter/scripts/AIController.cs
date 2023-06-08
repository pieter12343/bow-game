using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    public AIHP AIHP;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 Target;
    public Transform[] moveSpots;
    private int randomSpot;
    private int currentPos = 1;
    private int nextPos = 1;

    NavMeshAgent nav;

    public float distToPlayer = 5.0f;
    private float randomStrafeStartTime;
    private float waitStrafeTime;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;
    private float waitTime;
    public float startWaitTime = 1f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        UpdateDestination();
    }

    void Update()
    {
        if (Vector3.Distance(transform.position, Target) < 1)
        {
            IterateWaypointIndex();
            UpdateDestination();
        }
    }
    void UpdateDestination()
    {
        Target = waypoints[waypointIndex].position;
        agent.SetDestination(Target);
    }
    void IterateWaypointIndex()
    {
        waypointIndex++;
        if (waypointIndex == waypoints.Length)
        {
            waypointIndex = 0;
        }
    }
    void ChasePlayer()
    {
        if (AIHP.currentHealth >= 0)
        {
            float distance = Vector3.Distance(movementPlayer.playerPos, transform.position);

            if (distance <= chaseRadius && distance > distToPlayer)
            {
                nav.SetDestination(movementPlayer.playerPos);
            }
            else if (nav.isActiveAndEnabled && distance <= distToPlayer)
            {

            }
        }
    }

}
