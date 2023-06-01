using UnityEngine;
using UnityEngine.AI;


public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    EnemySpawn enemySpawn;
    GameObject hedef;
    public Animator animator;
    float distanceToStartRun = 30f;
    float distanceToHit = 1.7f;
    float distance;
    float health = 50f;
    float bulletDamage;



    void Start()
    {
        animator = GetComponent<Animator>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        agent = GetComponent<NavMeshAgent>();
        hedef = enemySpawn.target;

        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));

    }

    void Update()
    {
        if (enemySpawn.target == null)
        {
            hedef = enemySpawn.target;
        }
        if (health <= 0)
        {
            agent.velocity = Vector3.zero;
            agent.speed = 0f;
        }
        else 
        {
            agent.SetDestination(hedef.transform.position);
        }

        
        checkDistance();

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "bullet")
        {

            Bullet _bullet = other.gameObject.GetComponent<Bullet>();
            bulletDamage = _bullet.damage;
            health -= bulletDamage;
            Destroy(other.gameObject);
            if (health <= 0)
            {
                animator.SetInteger("deathType", Random.Range(0, 2));
                animator.SetBool("isDead", true);
                               
                Destroy(gameObject, 3f);
            }
        }

    }




    void checkDistance()
    {
        distance = Vector3.Distance(transform.position, hedef.transform.position);
        if (distance <= distanceToStartRun && distance > distanceToHit)
        {

            animator.SetInteger("runType", Random.Range(0, 2));
            animator.SetBool("isRunning", true);

            agent.speed = 4.5f;
        }
        if (distance <= distanceToHit)
        {
            agent.speed = 1f;
            animator.SetInteger("attackType", Random.Range(0, 4));
            animator.SetTrigger("attack");



        }
        else return;
    }


}






