using System;
using System.Collections;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;


public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    EnemySpawn enemySpawn;
    GameObject hedef;
    Animator animator;
    float distanceToStartRun = 30f;
    float distanceToHit = 1.7f;
    float distance;
    public float health = 50f;
    float bulletDamage;
    int zombieDamage = 5;

    GameObjects gameObjects;
    bool left, right, back;
    Vector3 destination = Vector3.zero;

    private void Awake()
    {
        gameObjects = FindObjectOfType<GameObjects>();
        animator = GetComponent<Animator>();
        enemySpawn = FindObjectOfType<EnemySpawn>();
        agent = GetComponent<NavMeshAgent>();
    }

    void Start()
    {
        hedef = enemySpawn.target;

        //Animasyonlarýn farklý görünmesi için, farklý framelerde baþlatýlmasý
        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));

        //Zombilerin seçtiði hedeflerin yerlerini bulmak için oluþturulan boolean
        left  = hedef.name == "lt1" || hedef.name == "lt2" || hedef.name == "lt3";
        right = hedef.name == "rt1" || hedef.name == "rt2" || hedef.name == "rt3";
        back  = hedef.name == "blt" || hedef.name == "brt";

        if (left || right) 
        {
           destination = hedef.transform.position + new Vector3(0,0,Random.Range(-1f,1.5f));
        }
        if (back) 
        {
           destination = hedef.transform.position;
        }


    

    }

    void Update()
    {
        //Navmash ile hedef belirlenmesi ve zombinin canýnýn kontrol edilerek, ölmüþse durdurulmasý
        if (health <= 0)
        {
            agent.velocity = Vector3.zero;
            agent.speed = 0f;
        }
        else
        {
            agent.SetDestination(destination);
        }

        checkDistance();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("bullet"))
        {
            Bullet _bullet = other.gameObject.GetComponent<Bullet>();
            bulletDamage = _bullet.damage;
            health -= bulletDamage;

            Destroy(other.gameObject);

            if (health <= 0)
            {
                animator.SetInteger("deathType", Random.Range(0, 2));
                animator.SetBool("isDead", true);

                if (left)
                    gameObjects.leftSpawn.Remove(gameObject);
                if (right)
                    gameObjects.rightSpawn.Remove(gameObject);
                if (back)
                    gameObjects.backSpawn.Remove(gameObject);

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
       
          
        



    }

    public void AnimationEventZombieHit() // Animation tarafýndan çaðrýlýr 
    {
        Debug.Log("HIT!");
        enemySpawn.trainHealth -= zombieDamage;
        Debug.Log(enemySpawn.trainHealth);

    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawSphere(destination, 0.1f);
    }



   
}






