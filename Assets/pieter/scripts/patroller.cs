using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class patroller : MonoBehaviour
{
    public Transform[] moveSpots;
    private int randomSpot;
    private int currentPos = 1;
    private int nextPos = 1;

    NavMeshAgent nav;

    public float distToPlayer = 5.0f;
    private float randomStrafeStartTime;
    private float waitStrafeTime;
    public float t_minStrafe;
    public float t_maxStrafe;

    public float chaseRadius = 20f;
    public float facePlayerFactor = 20f;
    private float waitTime;
    public float startWaitTime = 1f;
    private int randomStrafeDir;
    public Transform strafeLeft;
    public Transform strafeRight;
    public AIHP AIHP;

    private void Awake()
    {
        nav = GetComponent<NavMeshAgent>();
        nav.enabled = true;
    }

    private void Start()
    {
        waitTime = startWaitTime;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    private void Update()
    {
        float distance = Vector3.Distance(movementPlayer.playerPos, transform.position);
        if (distance > chaseRadius)
        {
            Patrol();
        }
        else if (distance <= chaseRadius)
        {
            //ChasePlayer();
            FacePlayer();
        }
    }

    void Patrol()
    {
        if (AIHP.currentHealth > 0)
        {
            nav.SetDestination(moveSpots[currentPos].position);

            if (currentPos >= moveSpots.Length)
            {
                currentPos = 0;
            }
            if (Vector3.Distance(transform.position, moveSpots[currentPos++].position) < 2.0f)
            {
                Debug.Log(currentPos);
                if (waitTime <= 0)
                {
                    nav.SetDestination(moveSpots[currentPos].position);

                    //randomSpot = Random.Range(0, moveSpots.Length);
                    waitTime = startWaitTime;
                }
                else { waitTime -= Time.deltaTime; }
            }
        }
        else
        {

        }
    }
    /*
    void ChasePlayer()
    {
        if (enemy.health >= 0)
        {
            float distance = Vector3.Distance(movementPlayer.playerPos, transform.position);

            if (distance <= chaseRadius && distance > distToPlayer)
            {
                nav.SetDestination(movementPlayer.playerPos);
            }
            else if (nav.isActiveAndEnabled && distance <= distToPlayer)
            {
                randomStrafeDir = Random.Range(0, 2);
                randomStrafeStartTime = Random.Range(t_minStrafe, t_maxStrafe);
                if (waitStrafeTime <= 0)
                {
                    if (randomStrafeDir == 0)
                    {
                        nav.SetDestination(strafeLeft.position);
                    }
                    else if (randomStrafeDir == 1)
                    {
                        nav.SetDestination(strafeRight.position);
                    }
                    waitStrafeTime = randomStrafeStartTime;
                }
                else
                {
                    waitStrafeTime -= Time.deltaTime;
                }
            }
        }
    }
    */
    public void FacePlayer()
    {
        if (AIHP.currentHealth > 0)
        {
            Vector3 direction = (movementPlayer.playerPos - transform.position).normalized;
            Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
            transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * facePlayerFactor);
        }
    }

}

