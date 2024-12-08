using UnityEngine;

public class PlayerHp : Hp
{
    override protected void Start()
    {
        base.Start();
        maxHealth = PlayerStats.Instance.MaxHp;
    }
    override protected void Die()
    {
        Debug.Log("U Died");
        //dodelat
    }





}
