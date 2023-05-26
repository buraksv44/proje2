
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    public Transform target;
    public int turretType;
    public float maxRange = 25f;
    public float minRange = 10f;
    GameObjects gameObjects;
    GameObject closestZombie = null;
    public Transform gun;
    public Transform barrel;
    public float turnSpeed = 5f;
    Quaternion defaultTurretPos;

    private void Awake()
    {
        gameObjects = GameObject.FindObjectOfType<GameObjects>();

    }
    void Start()
    {
        defaultTurretPos = gun.rotation;
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
            Debug.Log("pewpew");
        }
        else
        {
            target = null;
        }
    }


    void Update()
    {
        GunRotation();
    }


    void GunRotation()
    {
        if (target == null)
        {
            gun.rotation = Quaternion.Lerp(gun.rotation, defaultTurretPos, Time.deltaTime * turnSpeed);

        }
        else
        {

            Vector3 direction = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(direction);
            gun.rotation = Quaternion.Lerp(gun.rotation, lookRotation, Time.deltaTime * turnSpeed);

        }

    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position - Vector3.up * transform.position.y, maxRange);


        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position - Vector3.up * transform.position.y, minRange);

    }
}
