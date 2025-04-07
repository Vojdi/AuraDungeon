using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    int maxHp;
    public int MaxHp => maxHp;

    int damage;
    public int Damage => damage; 

    float range;
    public float Range => range;

    float movementSpeed;
    public float MovementSpeed => movementSpeed;

    float reloadTime;
    public float ReloadTime => reloadTime;

    float projectileSpeed;
    public float ProjectileSpeed => projectileSpeed;

    int aura;
    public int Aura => aura;

    bool hitInRoom;
    public bool HitInRoom => hitInRoom;

    private static PlayerStats instance;
    public static PlayerStats Instance => instance;
    void Awake()
    {
        instance = this;
        maxHp = 100;
        damage = 10;
        range = 15;
        movementSpeed = 7f;
        reloadTime = 1f;
        projectileSpeed = 20f;
        aura = 0;
        hitInRoom = false;
    }
    public static void ChangeAura(int value)
    {
        Instance.aura = value;
    }
    public void PowerUpAttackSpeed(float value)
    {
        float inversedReloadTime = 1 / reloadTime;
        reloadTime = 1/(inversedReloadTime + ((inversedReloadTime / 100) * value));
    }
    public void PowerUpAttackDamage(float value)
    {
        damage = damage + (int)Math.Ceiling((double)damage / 100 * value);
    }
    public void PowerUpAttackRange(float value)
    {
        range = range + (range/100 * value);
    }
    public void PowerUpMovementSpeed(float value)
    {
        movementSpeed = movementSpeed + (movementSpeed / 100 * value);
    }
    public void PowerUpProjectileSpeed(float value)
    {
        projectileSpeed = projectileSpeed + (projectileSpeed / 100 * value);
    }
    public void PowerUpMaxHp(float value)
    {
        maxHp = maxHp + (int)Math.Ceiling((double)maxHp / 100 * value);
        GetComponent<PlayerHp>().UpdateHp();
        
    }
    public void AddAura()
    {
        if(aura != 10)
        {
            aura += 1;
        }
    }
    public void MinusAura()
    {
        hitInRoom = true;
        aura = 0;
       
    }
    public void NewRoomHit()
    {

        hitInRoom = false;
       
    }

}
