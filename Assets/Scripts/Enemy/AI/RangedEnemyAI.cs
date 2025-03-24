using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using UnityEngine.EventSystems;



public class RangedEnemyAI : EnemyAI
{
    float idleMovementOpportunity = 0;
    bool isTriggered = false;
    bool lockedFleeState = false;
    float fleeSpeedMultiplier = 2f;
    bool delayBetweenFollowing = false;
    int currentBehaviour = 0;
    float reach;
    float sightRange;
    



    void Update()
    {


        CheckForImportantVariables();

        float enemyPlayerDistance = Vector3.Distance(PlayerMovement.PlayerPosition, transform.position);
        if (enemyPlayerDistance < es.SightRange || isTriggered)
        {
            agent.updateRotation = false;
            transform.LookAt(new Vector3(PlayerMovement.PlayerPosition.x, transform.position.y, PlayerMovement.PlayerPosition.z));
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
            if (delayBetweenFollowing)
            {
                return;
            }
            agent.speed = es.MovementSpeed;
            agent.autoBraking = false;
            if (es.AuraToughness >= PlayerStats.Instance.Aura)
            {//Enemy Followuje Hrace
                AttackState(enemyPlayerDistance);
            }
            else
            {
                agent.speed = es.MovementSpeed / 2;
                reach = reach / 1.5f;
                sightRange = sightRange / 1.5f;
                AttackState(enemyPlayerDistance);
            }
        }
        else //Prochazky
        {
            ProchazkyState();
        }
    }

    void ProchazkyState()
    {
        agent.updateRotation = true;
        agent.speed = es.MovementSpeed;
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
        if (lockedFleeState && enemyPlayerDistance > 6)
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
        Vector3 NewFleePosition = (GameManager.Instance.currentRoom.transform.position - transform.position).normalized * possibleMoveValues[Random.Range(0, 3)];
        return NewFleePosition;
    }
    void AttackState(float enemyPlayerDistance)
    {
        int behaviour;

        if (enemyPlayerDistance > reach)
        {
            //enenmy is far
            behaviour = 1;
            CheckForBehaviourChange(behaviour);
            agent.SetDestination(PlayerMovement.PlayerPosition);
            SetWalkingTrue();
        }
        else if (enemyPlayerDistance < reach / 1.5)
        {

            //enemy is too close
            behaviour = 3;
            agent.ResetPath();
            CheckForBehaviourChange(behaviour);
            asc.InitiateAttack();
            isWalking = true;
            FleeingState(enemyPlayerDistance);
        }
        else
        {

            //enemy is desired range
            behaviour = 2;
            agent.ResetPath();
            CheckForBehaviourChange(behaviour);
            asc.InitiateAttack();
            isWalking = false;
        }
    }
    IEnumerator DelayBetweenFollowing(float time)
    {
        yield return new WaitForSeconds(time);
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
        reach = es.Reach;
        sightRange = es.SightRange;
    }
    void CheckForBehaviourChange(int behaviour)
    {
        if (currentBehaviour != behaviour)
        {
            if(currentBehaviour - behaviour == 1 || currentBehaviour == 3 &&behaviour == 1)
            {
                currentBehaviour = behaviour;
                delayBetweenFollowing = true;
                StartCoroutine(DelayBetweenFollowing(0.5f));
            }
            else
            {
                currentBehaviour = behaviour;
                return;
            }
        }
        else
        {
            currentBehaviour = behaviour;
            return;
        }
        
    }
}
