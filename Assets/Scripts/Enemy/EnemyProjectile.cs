using UnityEngine;
using UnityEngine.Rendering;

public class EnemyProjectile : MonoBehaviour
{
    [SerializeField] Transform endProjectileTransform;
    [SerializeField] GameObject projectileDissapearParticle;
    Vector3 direction;
    Vector3 startSpawnerPos;
    float distanceTravelled;
    bool readyToTravel = false;
    float projectileSpeed;
    float projectileRange;

    public RangedEnemyAttack spawner;
    int spawnerDamage;
    private void Start()
    {
        projectileSpeed = spawner.GetComponent<EnemyStats>().ProjectileSpeed;
        projectileRange = spawner.GetComponent<EnemyStats>().ProjectileRange;
        spawnerDamage = spawner.GetComponent<EnemyStats>().Damage;
    }

    public void Cast()
    {
        direction = (PlayerMovement.PlayerPosition - spawner.transform.position).normalized;
        startSpawnerPos = spawner.transform.position;
        distanceTravelled = 0f;
        readyToTravel = true;
    }
    void Update()
    {
        if (readyToTravel)
        {
            Travel();
            CheckForDistanceTravelled();
        }
    }
    void Travel()
    {
        transform.Translate(direction * Time.deltaTime * projectileSpeed, Space.World);
    }
    void CheckForDistanceTravelled()
    {
        distanceTravelled = Vector3.Distance(endProjectileTransform.position, startSpawnerPos);
        if (distanceTravelled >= projectileRange)
        {
            AddToPool();
            Instantiate(projectileDissapearParticle, endProjectileTransform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject collision = other.transform.root.gameObject;
        if (collision.transform.root.GetComponent<EnemyStats>() == null)
        {
            var php = other.gameObject.GetComponent<PlayerHp>();
            if (php != null)
            {
                php.DoDmg(spawnerDamage);
            }
            AddToPool();
        }
    }
    void AddToPool()
    {
        spawner.projectiles.Add(this);
        this.gameObject.SetActive(false);
    }
}
