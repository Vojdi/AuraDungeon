using UnityEngine;
using System;

public class PlayerStats : MonoBehaviour
{
    // Instance
    private static PlayerStats instance;
    public static PlayerStats Instance => instance;

    // Stats
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

   
    private static (int maxHp, int damage, float range, float moveSpeed, float reload, float projSpeed)[] statPresets =
    {
        (100, 15, 20f, 7.5f, 1.2f, 20f),   
        (50, 10, 15f, 9.5f, 0.7f, 30f),  
        (150, 20, 30f, 5.5f, 1.7f, 10f)   
    };

    void Awake()
    {
        instance = this;

        int charId = PlayerPrefs.GetInt("charId");
        maxHp = statPresets[charId].maxHp;
        damage = statPresets[charId].damage;
        range = statPresets[charId].range;  
        movementSpeed = statPresets[charId].moveSpeed;
        reloadTime = statPresets[charId].reload;
        projectileSpeed = statPresets[charId].projSpeed;
        aura = 0;
        hitInRoom = false;
    }
    public void PowerUpAttackSpeed(float value)
    {
        float inversedReloadTime = 1 / reloadTime;
        reloadTime = 1 / (inversedReloadTime + ((inversedReloadTime / 100) * value));
    }

    public void PowerUpAttackDamage(float value)
    {
        damage += (int)Math.Ceiling((double)damage / 100 * value);
    }

    public void PowerUpAttackRange(float value)
    {
        range += (range / 100 * value);
    }

    public void PowerUpMovementSpeed(float value)
    {
        movementSpeed += (movementSpeed / 100 * value);
    }

    public void PowerUpProjectileSpeed(float value)
    {
        projectileSpeed += (projectileSpeed / 100 * value);
    }

    public void PowerUpMaxHp(float value)
    {
        maxHp += (int)Math.Ceiling((double)maxHp / 100 * value);
        GetComponent<PlayerHp>().UpdateHp();
    }

    public static void ChangeAura(int value)
    {
        Instance.aura = value;
    }

    public void AddAura()
    {
        if (aura < 10)
            aura++;
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
