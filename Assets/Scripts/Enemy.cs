using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    public GameObject enemyDestination;
    NavMeshAgent enemyNav;
    public GameObject enemy;

    // Start is called before the first frame update
    void Start()
    {
        enemyNav = GetComponent<NavMeshAgent>();
        enemy = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        enemyNav.SetDestination(enemyDestination.transform.position); 
    }
    
}
