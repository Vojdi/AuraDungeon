using UnityEngine;

public class EnemyHp : Hp
{
    
    override protected void Awake()
    {
        MaxHealth = 40;//temporary
        base.Awake();
    }

    
    override protected void Die()
    {
        Destroy(gameObject);
    }
}
