using UnityEngine;
using UnityEngine.AI;

public class EnemyAI : MonoBehaviour
{
    protected EnemyStats es;
    protected EnemyHp ehp;
    protected AnimationStateController asc;
    protected NavMeshAgent agent;
    protected bool isWalking = false;
    public bool IsWalking => isWalking;
    void Start()
    {
        ehp = GetComponent<EnemyHp>();
        es = GetComponent<EnemyStats>();
        asc = GetComponent<AnimationStateController>();
        agent = GetComponent<NavMeshAgent>();
    }

    
}
