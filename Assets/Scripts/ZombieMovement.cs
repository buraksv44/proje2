using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    GameObject hedef;

    void Start()
    {
      agent = GetComponent<NavMeshAgent>();
        hedef = GameObject.Find("Wagon");
    }

    void Update()
    {
        agent.SetDestination(hedef.transform.position);

    }


   
}
