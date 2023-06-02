using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public float bulletSpeed =25f;
    public float damage = 10f;
    Rigidbody rb;
    public void BulletTarget(Transform _target) 
    {
        target = _target;
    }

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
    
    void Start()
    {
        if (target!= null) 
        {
            Vector3 dir = target.position - transform.position;
            rb.velocity = dir.normalized * bulletSpeed;
        }
        
    }

    
    
    void Update()
    {
        if (target == null)
        {
            Destroy(gameObject);
        }
        else
            Destroy(gameObject, 3f);
        
        
    }
    

    }

