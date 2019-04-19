using UnityEngine;
using UnityEngine.AI;

public class WanderingAI : MonoBehaviour
{

    public float wanderRadius;
    public float wanderTimer;

    private Transform target;
    private NavMeshAgent agent;
    private float timer;

    // Added by mohanad
    public bool ChasePlayer { get; set; } = false;
    private Transform player;
    public static WanderingAI instance = null;
    //-----------------------------------------------

    // Added by mohanad
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag(Tags.player).transform;
    }
    //-----------------------------------------------


    void OnEnable()
    {
        agent = GetComponent<NavMeshAgent>();
        timer = wanderTimer;
    }

    
    void Update()
    {
        timer += Time.deltaTime;

        if (timer >= wanderTimer)
        {


            if (ChasePlayer == false)
            {
                Vector3 newPos = RandomNavSphere(transform.position, wanderRadius, -1);
                agent.SetDestination(newPos);

            }
            else
            {
                agent.SetDestination(player.position);
            }
            
            timer = 0;
        }
       
    }

    public static Vector3 RandomNavSphere(Vector3 origin, float dist, int layermask)
    {
        Vector3 randDirection = Random.insideUnitSphere * dist;

        randDirection += origin;

        NavMeshHit navHit;

        NavMesh.SamplePosition(randDirection, out navHit, dist, layermask);

        return navHit.position;
    }
}