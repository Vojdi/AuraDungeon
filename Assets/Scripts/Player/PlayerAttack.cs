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
        reloaded = true;
        lineRenderer = GetComponent<LineRenderer>();
        playerAnimationStateController = GetComponent<PlayerAnimationStateController>();
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
            StartCoroutine(Reload());
        }
    }
    IEnumerator Reload()
    {
        lineRenderer.material = lineMaterials[1];
        yield return new WaitForSeconds(PlayerStats.Instance.ReloadRate);
        reloaded = true;
        lineRenderer.material = lineMaterials[0];
    }
}
