using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using static UnityEngine.GraphicsBuffer;

public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    EnemySpawn enemySpawn ;
    GameObject hedef;

    void Start()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
        agent = GetComponent<NavMeshAgent>();
        hedef = enemySpawn.target;

    }

    void Update()
    {
        if (enemySpawn.target == null)
        {
            hedef = enemySpawn.target;

        }
        agent.SetDestination(hedef.transform.position);
       
    }

   

}
