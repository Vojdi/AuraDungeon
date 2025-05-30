using UnityEngine;
public class PlayerProjectile : MonoBehaviour
{
    [SerializeField] Transform endProjectileTransform;
    [SerializeField] GameObject projectileDissapearParticle;
    
    Vector3 direction;
    Vector3 startPlayerPos;
    float distanceTravelled;
    bool readyToTravel = false;
    public PlayerAttack spawner;
    
    void Update()
    {
        if (readyToTravel)
        {
            Travel();
            CheckForDistanceTravelled();
        }
    }
    public void Cast()
    {    
        direction = PlayerRotate.LookDirection.normalized;
        startPlayerPos = spawner.transform.position;
        distanceTravelled = 0f;
        readyToTravel = true;
    }
    void Travel()
    {
        transform.Translate(direction * Time.deltaTime * PlayerStats.Instance.ProjectileSpeed, Space.World);
    }
    void CheckForDistanceTravelled()
    {
        distanceTravelled = Vector3.Distance(endProjectileTransform.position, startPlayerPos);
        if (distanceTravelled >= PlayerStats.Instance.Range)
        {
            AddToPool();
            Instantiate(projectileDissapearParticle,endProjectileTransform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        GameObject collision = other.transform.root.gameObject;
        if (collision.GetComponent<PlayerStats>() == null)
        {
            EnemyHp enemyHp = collision.GetComponent<EnemyHp>();
            if (enemyHp != null)
            {
                enemyHp.DoDmg(PlayerStats.Instance.Damage);
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
