
using UnityEngine;
using UnityEngine.AI;

public class TestingEnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;

    void Start()
    {

    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var en = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.G))
        {
            if(PlayerStats.Instance.Aura == 10)
            {
                PlayerStats.ChangeAura(0);
            }
            else
            {
                PlayerStats.ChangeAura(10);
            }
            
        }
    }
}
