using UnityEngine;
using UnityEngine.AI;

public class RangedEnemyAI : EnemyAI
{
    float idleMovementOpportunity = 0;
    bool isTriggered = false;
    bool lockedFleeState = false;
    float fleeSpeedMultiplier = 2f;
    void Update()
    {
        CheckForImportantVariables();

        float enemyPlayerDistance = Vector3.Distance(PlayerMovement.PlayerPosition, transform.position);
        if (enemyPlayerDistance < es.SightRange || isTriggered)
        {
            agent.autoBraking = false;
            if (es.AuraToughness >= PlayerStats.Instance.Aura)
            {//Enemy Followuje Hrace
                AttackState(enemyPlayerDistance);
            }
            else
            {//Enemy zdrha
                FleeingState();
            }
        }
        else //Prochazky
        {
            ProchazkyState();
        }
    }
    private void CheckForImportantVariables()
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
    }

    Vector3 GetNewFleePosition()
    {
        int distance = Random.Range(11, 14);
        int[] possibleMoveValues = new int[] { distance, distance + 2, distance - 2 };
        Vector3 NewFleePosition = (Vector3.zero - transform.position).normalized * possibleMoveValues[Random.Range(0, 3)];
        return NewFleePosition;
    }
    void Prochazka()
    {
        int distance = Random.Range(3, 6);
        int[] possibleMoveValues = new int[] { distance, -distance, 0, 2 * distance, -2 * distance };
        Vector3 randomDistance = new Vector3(possibleMoveValues[Random.Range(0, 5)], 0, possibleMoveValues[Random.Range(0, 5)]);
        if (randomDistance == Vector3.zero)
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
    void ProchazkyState()
    {
        agent.autoBraking = true;
        if (!agent.pathPending && !agent.hasPath && !(agent.remainingDistance > agent.stoppingDistance))
        {
            isWalking = false;
            idleMovementOpportunity += Time.deltaTime;
        }
        if (idleMovementOpportunity > 1f)
        {
            Prochazka();
        }
    }
    void SetWalkingTrue()
    {
        isWalking = true;
        idleMovementOpportunity = 0;
    }
    void FleeingState()
    {
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
    void AttackState(float enemyPlayerDistance)
    {
        if (enemyPlayerDistance <= es.Reach)
        {
            asc.InitiateAttack();
            transform.LookAt(new Vector3(PlayerMovement.PlayerPosition.x, transform.position.y, PlayerMovement.PlayerPosition.z));
            isWalking = false;
            agent.ResetPath();

        }
        else
        {
            agent.SetDestination(PlayerMovement.PlayerPosition);
            SetWalkingTrue();
        }
    }
}
