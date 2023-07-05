using UnityEngine;

public class Bullet : MonoBehaviour
{
    Transform target;
    public float bulletSpeed =90f;
    public float damage = 5f;
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
            Vector3 dir = target.position+ new Vector3 (Random.Range(-0.5f,0.5f),Random.Range(0f,1.5f),0) - transform.position;
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

