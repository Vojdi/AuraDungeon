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
            Instantiate(projectilePrefab, projectileSpawnTransform.position, projectileSpawnTransform.rotation);
            reloaded = false;
        }
    }
    public void Reload()
    {
        reloaded = true;
    }
    
}
