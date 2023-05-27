using UnityEngine;
using UnityEngine.AI;


public class ZombieMovement : MonoBehaviour
{
    NavMeshAgent agent;
    EnemySpawn enemySpawn ;
    GameObject hedef;
    

    public void takeDamage() 
    {
      Destroy(gameObject);
    }    
    void Start()
    {
        enemySpawn = FindObjectOfType<EnemySpawn>();
        agent = GetComponent<NavMeshAgent>();
        hedef = enemySpawn.target;

    }

    void Update()
    {
        if (enemySpawn.target == null)
        {
            hedef = enemySpawn.target;

        }
        agent.SetDestination(hedef.transform.position);
       
    }

   

}
