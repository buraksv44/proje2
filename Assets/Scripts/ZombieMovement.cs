using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject wagon;
    Transform zombieTransform;

    void Start()
    {
        wagon = GameObject.Find("Wagon");
        Debug.Log(wagon.transform.position);
    }

    void Update()
    {
        ZombieRotation();

    }


    void ZombieRotation() 
    {
        transform.LookAt(wagon.transform);
    }
}
