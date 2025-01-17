
using UnityEngine;
using UnityEngine.AI;

public class TestingEnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy1;
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = FindAnyObjectByType<PlayerMovement>().gameObject.GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            var en = Instantiate(enemy, new Vector3(0, 0, 0), Quaternion.identity);
        }
        if (Input.GetKeyDown(KeyCode.Z))
        {
            var en = Instantiate(enemy1, new Vector3(0, 0, 0), Quaternion.identity);
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
        if (Input.GetKeyDown(KeyCode.F1)) { 
            lineRenderer.enabled = !lineRenderer.enabled;
        }
    }
}
