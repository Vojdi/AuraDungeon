using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerHp : Hp
{
    bool immortal;
    override protected void Start()
    {
        if(PlayerPrefs.GetString("Immortality") == "true")
        {
            immortal = true;
        }
        else
        {
            immortal = false;
        }
        MaxHealth = PlayerStats.Instance.MaxHp;
        base.Start();
    }
    override protected void Die()
    {
        GameManager.Instance.GameOver();
    }
    public void UpdateHp()
    {
        health += PlayerStats.Instance.MaxHp - MaxHealth;
        MaxHealth = PlayerStats.Instance.MaxHp;
    }
    public override void DoDmg(int Dmg)
    {
        if (!immortal)
        {
            if(Dmg > 0)
            {
                PlayerStats.Instance.MinusAura();
            }
            base.DoDmg(Dmg);
        }
    }
}
