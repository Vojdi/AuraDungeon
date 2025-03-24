using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHp : Hp
{
    
    override protected void Start()
    {
        MaxHealth = PlayerStats.Instance.MaxHp;
        base.Start();
    }
    override protected void Die()
    {
        GameManager.Instance.GameOver();
    }
}
