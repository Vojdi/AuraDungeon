using UnityEngine;
using UnityEngine.AI;

public class SkeletonEliteAI : MonoBehaviour
{
    protected EnemyStats es;
    protected EnemyHp ehp;
    protected AnimationStateController asc;
    protected NavMeshAgent agent;


    private float minReach;
    private float maxReach;   
    private bool isInMeleeRange;

   
    private float moveCooldownTimer = 0f;
    private float moveCooldownDuration = 0.2f;

    public static int AttackType { get; private set; }
    public bool IsWalking => agent.velocity.magnitude > 0.1f;

    void Start()
    {
        ehp = GetComponent<EnemyHp>();
        es = GetComponent<EnemyStats>();
        asc = GetComponent<AnimationStateController>();
        agent = GetComponent<NavMeshAgent>();
        agent.speed = es.MovementSpeed;

       
        if (es != null)
        {
            minReach = 5;
            maxReach = es.Reach;
        }
    }

    void Update()
    {
        float distance = Vector3.Distance(PlayerMovement.PlayerPosition, transform.position);
        isInMeleeRange = distance <= minReach;

       
        if (distance <= maxReach)
        {
            transform.LookAt(new Vector3(
                PlayerMovement.PlayerPosition.x,
                transform.position.y,
                PlayerMovement.PlayerPosition.z));
        }

       
        if (isInMeleeRange)
        {
            if (!agent.isStopped)
            {
                agent.isStopped = true;
                moveCooldownTimer = moveCooldownDuration; 
            }
        }
        else
        {
            if (moveCooldownTimer <= 0f)
            {
                agent.isStopped = false;
                agent.SetDestination(PlayerMovement.PlayerPosition);
            }
        }

        // Update the cooldown timer
        if (moveCooldownTimer > 0f)
        {
            moveCooldownTimer -= Time.deltaTime;
        }

        // Attack logic
        if (distance > maxReach)
        {
            AttackType = 1;
            asc.InitiateAttack();
        }
        else if (isInMeleeRange)
        {
            AttackType = 0;
            asc.InitiateAttack();
        }
    }

   
}
