using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    NavMeshAgent agent;
    public Transform[] waypoints;
    int waypointIndex;
    Vector3 Target;

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

}
