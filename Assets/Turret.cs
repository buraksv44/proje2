
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    public Transform target;
    public int turretType;
    public float maxRange = 22f;
    public float minRange = 6f;
    GameObjects gameObjects;
    GameObject closestZombie = null;

    private void Awake()
    {
        gameObjects = GameObject.FindObjectOfType<GameObjects>();
    }
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
    }

    void UpdateTarget()
    {
        List<GameObject> zombies;

        if (turretType == 0)
        {
            zombies = gameObjects.leftSpawn;
        }
        else if (turretType == 1)
        {
            zombies = gameObjects.backSpawn;
        }
        else
        {
            zombies = gameObjects.rightSpawn;
        }

        //Debug.Log("turretType:"+ turretType +"  "+ zombies.Count);
        float shortestDistance = Mathf.Infinity;
        closestZombie = null;

        if (closestZombie == null)
        {
            foreach (GameObject zombie in zombies)
            {
                float distanceToZombie = Vector3.Distance(transform.position, zombie.transform.position);

                if (distanceToZombie < shortestDistance && distanceToZombie > minRange)
                {
                    shortestDistance = distanceToZombie;
                    closestZombie = zombie;
                }
            }
        }

        if (closestZombie != null && shortestDistance <= maxRange && shortestDistance >= minRange)
        {
            target = closestZombie.transform;
            Debug.Log("targethere");
        }
        else
        {
            target = null;
        }
    }


    void Update()
    {

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, maxRange);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, minRange);

    }
}
