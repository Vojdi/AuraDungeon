using UnityEngine;

public class EnemyHp : Hp
{
    EnemyStats stats;
    [SerializeField] GameObject dieParticle;
    override protected void Start()
    {
        stats = GetComponent<EnemyStats>();
        MaxHealth = stats.MaxHp;
        base.Start();
    }

    
    override protected void Die()
    {
        GameManager.Instance.EnemyDied(gameObject);
        Instantiate(dieParticle, new Vector3(transform.position.x, transform.position.y + 2, transform.position.z),Quaternion.identity );
        Destroy(gameObject);
    }
}
