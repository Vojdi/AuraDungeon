using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Material[] lineMaterials;
    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] GameObject projectilePrefab;   
    public GameObject ProjectilePrefab => projectilePrefab;
    LineRenderer lineRenderer;
    public static ObjectPool PlayerObjPool;

    PlayerAnimationStateController playerAnimationStateController;

    bool reloaded;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerAnimationStateController = GetComponent<PlayerAnimationStateController>();
        reloaded = true;
        PlayerObjPool = GetComponent<ObjectPool>();
    }
    void Update()
    {
        if (Input.GetButton("Attack") && reloaded)
        {
            lineRenderer.material = lineMaterials[1];
            playerAnimationStateController.InitiateAttack();
        }
        else if(Input.GetButton("Attack"))
        {
            lineRenderer.material = lineMaterials[1];
        }
        else
        {
            lineRenderer.material = lineMaterials[0];
        }
    }
    public void Attack()
    {
        if (reloaded) 
        {

            Projectile projectile = PlayerObjPool.projectiles[0];
            PlayerObjPool.projectiles.Remove(PlayerObjPool.projectiles[0]);
            projectile.gameObject.SetActive(true);
            projectile.transform.position = projectileSpawnTransform.position;
            projectile.transform.rotation = projectileSpawnTransform.rotation;
            projectile.Cast();
            reloaded = false;
        }
    }
    public void Reload()
    {
        reloaded = true;
    } 
}
