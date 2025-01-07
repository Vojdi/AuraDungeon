using UnityEngine;
using UnityEngine.AI;

public class MeleeAI : MonoBehaviour
{
    EnemyHp ehp;
    NavMeshAgent agent;
    int sightRange;
    int auraToughness;
    float idleMovementOpportunity = 0;
    bool isWalking = false;
    bool isTriggered = false;
    public bool IsWalking => isWalking;
    
    void Start()
    {
        ehp = GetComponent<EnemyHp>();
        agent = GetComponent<NavMeshAgent>();
        sightRange = 15;//dokud nejsou EnemyStats, scalovat Animace se stats
        auraToughness = 5;//---------------------
    }
    void Update()
    {
        if(ehp.MaxHealth != ehp.Health)
        {
            isTriggered = true;
        }
        if(auraToughness > PlayerStats.Instance.Aura)
        {

            if (Vector3.Distance(PlayerMovement.PlayerPosition, transform.position) < sightRange || isTriggered)
            {
                agent.SetDestination(PlayerMovement.PlayerPosition);
                isWalking = true;
            }
            else
            {
                
                if(!agent.pathPending && agent.remainingDistance <= agent.stoppingDistance)
                {
                    isWalking = false;
                    idleMovementOpportunity += Time.deltaTime * 1;
                }
                if(idleMovementOpportunity > 1f)
                {
                    idleMovementOpportunity = 0;
                    Prochazky();
                }
            }
        }
        else
        {
            //dodelat zdrhani enemy
        }
    }
    void Prochazky()
    {
        int distance = Random.Range(3,6);
        int[] possibleValues = new int[] { distance,-distance,0,2*distance,-2*distance};
        agent.SetDestination(transform.position + new Vector3(possibleValues[Random.Range(0,5)], 0, possibleValues[Random.Range(0, 5)]));
        isWalking = true;
    }
}
