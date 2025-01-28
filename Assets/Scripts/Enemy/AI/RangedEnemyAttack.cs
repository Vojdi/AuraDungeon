using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class RangedEnemyAttack : MonoBehaviour
{
    [SerializeField] Transform projectileSpawnTransform;
    [SerializeField] GameObject projectilePrefab;
    public List<EnemyProjectile> projectiles = new List<EnemyProjectile>();

    private void Start()
    {
        var projectile = projectilePrefab.GetComponent<EnemyProjectile>();
        for (int i = 0; i < 3; i++)
        {
            var prj = Instantiate(projectile, Waste.Instance.transform);
            prj.spawner = this;
            projectiles.Add(prj);
            prj.gameObject.SetActive(false);
        }
    }
    public void Attack()
    {
        EnemyProjectile projectile = projectiles[0];
        projectiles.Remove(projectiles[0]);
        projectile.gameObject.SetActive(true);
        projectile.transform.position = projectileSpawnTransform.position;
        projectile.transform.rotation = projectileSpawnTransform.rotation;
        projectile.Cast();
    }
}
