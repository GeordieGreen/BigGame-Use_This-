using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;


public class StateMachine : MonoBehaviour
{
    public NavMeshAgent nMesh;
    public Transform player;
    public LayerMask whoIsPlayer;
    public LayerMask whatIsGround;

    public Vector3 walkDestination;
    bool walkPointSet;
    bool playerInRange;
    public float walkRange;
    public float sightRange;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        nMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        playerInRange = Physics.CheckSphere(transform.position, sightRange, whoIsPlayer);

        if (!playerInRange)
        {
            Patrol();
        }
        if (playerInRange)
        {
            Chase();
        }
    }

    private void Patrol()
    {
        if (!walkPointSet)
        {
            SearchWalkPoint();

            if (walkPointSet)
            {
                nMesh.SetDestination(walkDestination);
            }

            Vector3 distanceToWalkDestination = transform.position - walkDestination;

            if (distanceToWalkDestination.magnitude < 1f)
            {
                walkPointSet = false;
            }
        }
    }

    private void SearchWalkPoint()
    {
        float randZ = Random.Range(-walkRange, walkRange);
        float randX = Random.Range(-walkRange, walkRange);

        walkDestination = new Vector3(transform.position.x + randX, transform.position.y, transform.position.z + randZ);

        if (Physics.Raycast(walkDestination, -transform.up, 2f, whatIsGround))
        {
            walkPointSet = true;
        }
    }

    private void Chase()
    {
        nMesh.SetDestination(player.position);
    }

}
