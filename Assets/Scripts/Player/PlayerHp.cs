using UnityEngine;

public class PlayerHp : Hp
{
    override protected void Awake()
    {
        MaxHealth = PlayerStats.Instance.MaxHp;
        base.Awake();
    }
    override protected void Die()
    {
        Debug.Log("U Died");
        //dodelat
    }





}
