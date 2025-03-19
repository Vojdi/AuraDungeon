
using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class TestingEnemySpawn : MonoBehaviour
{
    [SerializeField] GameObject enemy;
    [SerializeField] GameObject enemy1;
    [SerializeField] GameObject enemy2;
    [SerializeField] GameObject enemy3;
    LineRenderer lineRenderer;

    void Start()
    {
        lineRenderer = FindAnyObjectByType<PlayerMovement>().gameObject.GetComponent<LineRenderer>();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            SpawnEnemy(enemy);
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            SpawnEnemy(enemy1);
        }
        if (Input.GetKeyDown(KeyCode.U))
        {
            SpawnEnemy(enemy2);
        }
        if (Input.GetKeyDown(KeyCode.I))
        {
            SpawnEnemy(enemy3);
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
        IEnumerator Cook(GameObject en)
        {
            yield return null;
            en.SetActive(false);
            en.transform.position = new Vector3(0, 0.5f, 0);
            en.SetActive(true);
        }
        void SpawnEnemy(GameObject enemy){
            var en = Instantiate(enemy, new Vector3(0, 100, 0), Quaternion.identity);
            StartCoroutine(Cook(en));
        }
    }
    
}
