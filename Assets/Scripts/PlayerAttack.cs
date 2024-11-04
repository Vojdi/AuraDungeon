using System;
using System.Collections;
using Unity.Mathematics;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Material[] lineMaterials;
    [SerializeField] Transform projectileSpawnLocation;
    [SerializeField] GameObject projectilePrefab;
    PlayerStats playerStats;
    LineRenderer lineRenderer;
    bool reloaded;
    void Start()
    {
        reloaded = true;
        playerStats = GetComponent<PlayerStats>();
        lineRenderer = GetComponent<LineRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Attack"))
        {
            Attack();
        }
    }
    void Attack()
    {
        if (reloaded) 
        {
            Instantiate(projectilePrefab, projectileSpawnLocation.position, transform.rotation);
            reloaded = false;
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        lineRenderer.material = lineMaterials[1];
        yield return new WaitForSeconds(playerStats.ReloadRate);
        reloaded = true;
        lineRenderer.material = lineMaterials[0];
    }
}
