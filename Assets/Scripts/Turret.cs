
using System.Collections.Generic;
using UnityEngine;


public class Turret : MonoBehaviour
{
    public Transform target;
    public int turretType;
    public float maxRange = 25f;
    public float minRange = 10f;
    public float turnSpeed = 5f;
    GameObjects gameObjects;
    GameObject closestZombie = null;
    public Transform gun;
    public Transform barrel;
    public GameObject bulletPrefab;
    public Transform firePoint;
    
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

        
        float shortestDistance = Mathf.Infinity;
        closestZombie = null;

        if (closestZombie == null)
        {
            foreach (GameObject zombie in zombies)
            {
                if (zombie != null) 
                { 
                float distanceToZombie = Vector3.Distance(transform.position, zombie.transform.position);

                if (distanceToZombie < shortestDistance && distanceToZombie > minRange)
                {
                    shortestDistance = distanceToZombie;
                    closestZombie = zombie;
                }
                }
            }
        }

        if (closestZombie != null && shortestDistance <= maxRange && shortestDistance >= minRange)
        {
            target = closestZombie.transform;
            Shoot();
           
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

    void Shoot() 
    {
        GameObject _bullet = (GameObject)Instantiate(bulletPrefab,firePoint.position, firePoint.rotation);
        Bullet bullet = _bullet.GetComponent<Bullet>();

        if (bullet != null)
            bullet.BulletTarget(target);
    }

    private void OnDrawGizmosSelected()
    {
        //Gizmos.color = Color.yellow;
        //Gizmos.DrawWireSphere(transform.position - Vector3.up * transform.position.y, maxRange);


        //Gizmos.color = Color.red;
        //Gizmos.DrawWireSphere(transform.position - Vector3.up * transform.position.y, minRange);

        Gizmos.color = Color.green;
        Gizmos.DrawLine(gun.position,gun.position+gun.forward*maxRange);

    }
}
