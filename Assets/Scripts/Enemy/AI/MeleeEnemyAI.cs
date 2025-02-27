
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class MeleeEnemyAI : EnemyAI
{

    float idleMovementOpportunity = 0;
    bool isTriggered = false;
    bool lockedFleeState = false;
    float fleeSpeedMultiplier = 2f;
    bool delayBetweenFollowing = false;



    void Update()
    {
        
        CheckForImportantVariables();
        if (lockedFleeState)
        {
            if (!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
            {
                lockedFleeState = false;
                agent.speed = es.MovementSpeed;
            }
            else
            {
                return;
            }
        }
        agent.speed = es.MovementSpeed;
        if (delayBetweenFollowing)
        {
            return;
        }
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
                FleeingState(enemyPlayerDistance);
            }
        }
        else //Prochazky
        {
            ProchazkyState();
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
    void Prochazka()
    {
        int distance = Random.Range(3, 5);
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

    void FleeingState(float enemyPlayerDistance)
    {
        Vector3 directionFromPlayer = (transform.position - PlayerMovement.PlayerPosition).normalized;
        Vector3 fleePosition = transform.position + directionFromPlayer * 2;
        if (!NavMesh.SamplePosition(fleePosition, out NavMeshHit hit, 1, NavMesh.AllAreas))
        {
                fleePosition = GetNewFleePosition() + transform.position;
                lockedFleeState = true;
                agent.speed *= fleeSpeedMultiplier;
        }
        if(lockedFleeState && enemyPlayerDistance > 10)
        {
            isWalking = false;
        }
        else
        {
            agent.SetDestination(fleePosition);
            SetWalkingTrue();
        }
    }
    Vector3 GetNewFleePosition()
    {
        int distance = Random.Range(11, 14);
        int[] possibleMoveValues = new int[] { distance, distance + 2, distance - 2 };
        Vector3 NewFleePosition = (Vector3.zero - transform.position).normalized * possibleMoveValues[Random.Range(0, 3)];
        return NewFleePosition;
    }
    void AttackState(float enemyPlayerDistance)
    {
        if (enemyPlayerDistance <= es.Reach)
        {
            asc.InitiateAttack();
            transform.LookAt(new Vector3(PlayerMovement.PlayerPosition.x, transform.position.y, PlayerMovement.PlayerPosition.z));
            isWalking = false;
            agent.ResetPath();
            delayBetweenFollowing = true;
            StartCoroutine(DelayBetweenFollowing());

        }
        else
        {
            agent.SetDestination(PlayerMovement.PlayerPosition);
            SetWalkingTrue();
        }
    }
    IEnumerator DelayBetweenFollowing()
    {
        yield return new WaitForSeconds(0.5f);
        delayBetweenFollowing = false;
    }
    void SetWalkingTrue()
    {
        isWalking = true;
        idleMovementOpportunity = 0;
    }
    private void CheckForImportantVariables()
    {
        if (ehp.MaxHealth != ehp.Health)
        {
            isTriggered = true;
        }
    }
}
