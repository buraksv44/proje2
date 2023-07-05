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
    public GameObject bulletPrefab;
    Transform firePoint;
    public GameObject muzzlePrefab;
    public List<Transform> firepoints;
    Quaternion defaultTurretPos;
    Quaternion lookRotation;
    float rotationThreshold = 4f;
    float timeToFire = 0f;
    public float fireRate = 1f;
    public List<Animator> barrelAnimators;
    int index = 0;
    public bool isGatling;
    
    private void Awake()
    {
        gameObjects = FindObjectOfType<GameObjects>();
        GetBarrelAnimations();
    }
    void Start()
    {
        defaultTurretPos = gun.rotation;
        if (gameObjects != null)
        {
            InvokeRepeating("UpdateTarget", 0f, 0.5f);
        }
    }

    void GetBarrelAnimations() 
    {
        for (int i = 0; i < barrelAnimators.Count; i++)
        {
            gameObject.transform.GetChild(0).GetChild(0).GetChild(1).GetChild(0).GetChild(i).gameObject.GetComponent<Animator>();
        }
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
            if (isGatling) 
            {
                barrelAnimators[0].SetBool("isFiring", true);
            }
            yield return null;
        }
       
        Shoot();
    }
    
    void GunRotation()
    {
        if (target == null)
        {
            gun.rotation = Quaternion.Lerp(gun.rotation, defaultTurretPos, Time.deltaTime * turnSpeed);
            if (isGatling)
                barrelAnimators[0].SetBool("isFiring", false);
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
            Transform _firepoint = BarrelToFire();
            timeToFire = Time.time + 1 / fireRate;
            GameObject _bullet = Instantiate(bulletPrefab, _firepoint.position, _firepoint.rotation);
            
            Bullet bullet = _bullet.GetComponent<Bullet>();
            GameObject _muzzlePrefab = Instantiate(muzzlePrefab, _firepoint.position, _firepoint.rotation);
            Destroy(_muzzlePrefab, 1f);
            
            if (bullet != null)
                bullet.BulletTarget(target);
        }
    }
    Transform BarrelToFire()
    {
        if (index + 1 <= firepoints.Count)
        {
            firePoint = firepoints[index];

            if (!isGatling)
            {
                barrelAnimators[index].speed = fireRate;
                barrelAnimators[index].SetTrigger("fire");
            }
            
            index++;
            
            if (index == firepoints.Count)
            {
                index = 0;
            }
        }
        return firePoint;
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
