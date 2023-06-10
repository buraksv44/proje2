
using System.Collections;
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
    public GameObject muzzlePrefab;
    
    Quaternion defaultTurretPos;
    Quaternion lookRotation;
    float rotationThreshold = 4f;
    Animator barrelAnimator;
    float timeToFire = 0f;
    public float fireRate = 30f;




    private void Awake()
    {
        gameObjects = GameObject.FindObjectOfType<GameObjects>();
        barrelAnimator = gameObject.GetComponentInChildren<Animator>();

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


    IEnumerator waitForShoot() 
    {
        while(Quaternion.Angle(gun.rotation, lookRotation)> rotationThreshold)
        {
            yield return null;
        }
         Shoot();
    }
    
    
    void GunRotation()
    {
        if (target == null)
        {
            gun.rotation = Quaternion.Lerp(gun.rotation, defaultTurretPos, Time.deltaTime * turnSpeed);
            
        }
        else
        {

            Vector3 direction = target.position+Vector3.up - transform.position;
            lookRotation = Quaternion.LookRotation(direction);
            gun.rotation = Quaternion.Lerp(gun.rotation, lookRotation, Time.deltaTime * turnSpeed);
            
            StartCoroutine(waitForShoot());
        }

    }

    void Shoot() 
    {
        if (Time.time >= timeToFire)
        {
            timeToFire = Time.time + 1 / fireRate;
            GameObject _bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Bullet bullet = _bullet.GetComponent<Bullet>();
            GameObject _muzzlePrefab = Instantiate(muzzlePrefab, firePoint.position, firePoint.rotation);
            Destroy(_muzzlePrefab, 1f);
            
            barrelAnimator.SetTrigger("fire");

            if (bullet != null)
                bullet.BulletTarget(target);
        }
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
