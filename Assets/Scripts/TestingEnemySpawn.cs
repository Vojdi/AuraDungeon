
using UnityEngine;
using UnityEngine.AI;

public class TestingEnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    int time = 0;
    void Start()
    {
        
    }
    void Update()
    {
        if(time % 2000 == 0)
        {
            var en = Instantiate(enemy, new Vector3(Random.Range(0,10),0,Random.Range(0,10)), Quaternion.identity);
            en.GetComponent<NavMeshAgent>().SetDestination(PlayerMovement.PlayerPosition);
        }
        time++;
        Debug.Log(time);
    }
}
