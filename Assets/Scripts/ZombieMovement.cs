using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZombieMovement : MonoBehaviour
{
    GameObject wagon;
    Vector3 zombieSize;
    Vector3 target;
    //Transform zombieTransform;

    void Start()
    {
        wagon = GameObject.Find("Wagon");
        Vector3 zombieSize= GetComponent<Collider>().bounds.size;
        Debug.Log(wagon.transform.position);
    }

    void Update()
    {
        ZombieRotation();
        
    }


    void ZombieRotation() 
    {
        target= new Vector3 (wagon.transform.position.x,zombieSize.y, wagon.transform.position.z);
        transform.LookAt(target);
        
    }

}
