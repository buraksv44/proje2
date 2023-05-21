using System;
using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;

public class Turret : MonoBehaviour
{
    public Transform target;
    public int turretType;
    public float maxRange = 22f;
    public float minRange = 6f;
    Array zombies;
    GameObjects gameObjects;
    public GameObject closestZombie = null;

    private void Awake()
    {
        gameObjects = GameObject.FindObjectOfType<GameObjects>();
    }

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget() 
    {
        GameObject[] zombies;

        

        if (turretType == 0)
        {
        zombies = gameObjects.leftSpawn.ToArray();

        }
        else if (turretType == 1) 
        {
        zombies = gameObjects.backSpawn.ToArray();
        }
            
        else 
        {
         zombies = gameObjects.rightSpawn.ToArray();

        }
        
        Debug.Log("turretType:"+ turretType +"  "+ zombies.Length);
        float shortestDistance = Mathf.Infinity;
        
        //GameObject closestZombie = null;
        
        if (closestZombie == null) 
        {
            foreach (GameObject zombie in zombies)
            {
                float distanceToZombie = Vector3.Distance(transform.position, zombie.transform.position);
                if (distanceToZombie < shortestDistance)
                {
                    shortestDistance = distanceToZombie;
                    closestZombie = zombie;
                    
                }
        }
        }

        if (closestZombie != null && shortestDistance <= maxRange && shortestDistance >= minRange)
        {
            target = closestZombie.transform;
            
        }
        else 
        {
            target=null;
        }
    
    }

    // Update is called once per frame
    void Update()
    {
        //if (target != null) 
        //{
        //    return;
        //}
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minRange);

    }
}
