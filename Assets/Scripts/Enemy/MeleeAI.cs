using Unity.Burst.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : MonoBehaviour
{
    EnemyStats es;
    EnemyHp ehp;
    AnimationStateController asc;
    NavMeshAgent agent;

    int sightRange;
    int auraToughness;

    float idleMovementOpportunity = 0;
    bool isTriggered = false;
    
    bool lockedFleeState = false;
    float fleeSpeedMultiplier = 2f;
    bool isWalking = false;
    public bool IsWalking => isWalking;

    bool isAttacking = false;
    public bool IsAttacking => isAttacking;

    void Start()
    {
        ehp = GetComponent<EnemyHp>();
        es = GetComponent<EnemyStats>();
        asc = GetComponent<AnimationStateController>();
        agent = GetComponent<NavMeshAgent>();
    }
    void Update()
    {
        if (ehp.MaxHealth != ehp.Health)
        {
            isTriggered = true;
        }
        if (lockedFleeState && !agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
        {
            lockedFleeState = false;
            agent.speed /= fleeSpeedMultiplier;
        }
        else if (lockedFleeState)
        {
            return;
        }
        agent.speed = es.MovementSpeed;
        float enemyPlayerDistance = Vector3.Distance(PlayerMovement.PlayerPosition, transform.position);
        if (enemyPlayerDistance < es.SightRange || isTriggered)
        {
            agent.autoBraking = false;
            if (es.AuraToughness > PlayerStats.Instance.Aura)
            {//Enemy Followuje Hrace
                if(enemyPlayerDistance <= es.Reach)
                {
                    isAttacking = true;
                    isWalking = false;
                    agent.ResetPath();
                }
                else
                {
                    agent.SetDestination(PlayerMovement.PlayerPosition);
                    SetWalkingTrue();
                }     
            }
            else
            {//Enemy zdrha
                Vector3 directionFromPlayer = (transform.position - PlayerMovement.PlayerPosition).normalized;
                Vector3 fleePosition = transform.position + directionFromPlayer * 2;
                if (!NavMesh.SamplePosition(fleePosition, out NavMeshHit hit, 1, NavMesh.AllAreas))
                {
                    Vector3 newFleePosition = GetNewFleePosition();
                    agent.SetDestination(newFleePosition + transform.position);
                    lockedFleeState = true;
                    agent.speed *= fleeSpeedMultiplier;
                }
                else
                {
                    agent.SetDestination((transform.position + directionFromPlayer * 2));
                }
                SetWalkingTrue();
            }
        }
        else //Prochazky
        {
            agent.autoBraking = true;
            if (!agent.pathPending &&!agent.hasPath && !(agent.remainingDistance > agent.stoppingDistance))
            {
                isWalking = false;
                idleMovementOpportunity += Time.deltaTime * 1;
            }
            if (idleMovementOpportunity > 1f)
            {
                Prochazky();
            }
        }
    }

    Vector3 GetNewFleePosition()
    {
        int distance = Random.Range(11, 14);
        int[] possibleMoveValues = new int[] { distance, distance + 2, distance - 2 };
        Vector3 NewFleePosition = (Vector3.zero - transform.position).normalized * possibleMoveValues[Random.Range(0, 3)];
        return NewFleePosition;
    }
    void Prochazky()
    {
        int distance = Random.Range(3, 6);
        int[] possibleMoveValues = new int[] { distance, -distance, 0, 2 * distance, -2 * distance };
        Vector3 randomDistance = new Vector3(possibleMoveValues[Random.Range(0, 5)], 0, possibleMoveValues[Random.Range(0, 5)]);
        if(randomDistance == Vector3.zero)
        {
            return;
        }
        Vector3 desiredPosition = transform.position + randomDistance;
        if (NavMesh.SamplePosition(desiredPosition, out NavMeshHit hit, 1, NavMesh.AllAreas))
        {
            Vector3 validPosition = hit.position;
            agent.SetDestination(validPosition);
            SetWalkingTrue();
        }
    }
    void SetWalkingTrue()
    {
        isWalking = true;
        idleMovementOpportunity = 0;
    }
    public void StopAttacking()
    {
        isAttacking = false;
    }
}
