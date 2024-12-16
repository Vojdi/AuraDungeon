using UnityEngine;

public class EnemyHp : Hp
{
    
    override protected void Start()
    {
        MaxHealth = 40;//temporary
        base.Start();
    }

    
    override protected void Die()
    {
        Destroy(gameObject);
    }
}
