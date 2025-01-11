using UnityEngine;

public class EnemyHp : Hp
{
    EnemyStats stats;
    
    override protected void Start()
    {
        stats = GetComponent<EnemyStats>();
        MaxHealth = stats.MaxHp;
        base.Start();
    }

    
    override protected void Die()
    {
        Destroy(gameObject);
    }
}
