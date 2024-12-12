using System.Collections;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Material[] lineMaterials;

    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] GameObject projectilePrefab;
    LineRenderer lineRenderer;

    PlayerAnimationStateController playerAnimationStateController;

    bool reloaded;
    void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        playerAnimationStateController = GetComponent<PlayerAnimationStateController>();
        reloaded = true;
    }
    void Update()
    {
        if (Input.GetButton("Attack") && reloaded)
        {
            playerAnimationStateController.InitiateAttack();
        }
        
    }
    public void Attack()
    {
        if (reloaded) 
        {
            Instantiate(projectilePrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
            reloaded = false;
        }
    }
    public void Reload()
    {
        lineRenderer.material = lineMaterials[0];
        reloaded = true;
    }
    public void StartAttack() {
        lineRenderer.material = lineMaterials[1];
    }
}
