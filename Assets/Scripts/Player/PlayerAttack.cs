using System.Collections.Generic;
using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Material[] lineMaterials;
    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] GameObject[] projectileTypes;
    GameObject projectilePrefab;   
    public GameObject ProjectilePrefab => projectilePrefab;
    LineRenderer lineRenderer;
    public List<PlayerProjectile> projectiles;
    

    PlayerAnimationStateController playerAnimationStateController;

    bool reloaded;
    void Start()
    {
        projectilePrefab = projectileTypes[PlayerPrefs.GetInt("charId")];
        lineRenderer = GetComponent<LineRenderer>();
        playerAnimationStateController = GetComponent<PlayerAnimationStateController>();
        reloaded = true;

        var projectile = ProjectilePrefab.GetComponent<PlayerProjectile>();
        for (int i = 0; i < 5; i++)
        {
            var prj = Instantiate(projectile, Waste.Instance.transform);
            prj.spawner = this;
            projectiles.Add(prj);
            prj.gameObject.SetActive(false);

        }
    }
    void Update()
    {
        if (Input.GetButton("Attack") && reloaded)
        {
            lineRenderer.material = lineMaterials[1];
            playerAnimationStateController.InitiateAttack();
        }
    }
    public void Attack()
    {
        if (reloaded) 
        {
            PlayerProjectile projectile = projectiles[0];
            projectiles.Remove(projectiles[0]);
            projectile.gameObject.SetActive(true);
            projectile.transform.position = projectileSpawnTransform.position;
            projectile.transform.rotation = projectileSpawnTransform.rotation;
            projectile.Cast();
            reloaded = false;
        }
    }
    public void Reload()
    {
        lineRenderer.material = lineMaterials[0];
        reloaded = true;
    } 
}
