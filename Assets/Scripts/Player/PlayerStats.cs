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
        (85, 14, 17f, 7f, 1.2f, 20f),   
        (65, 9, 14f, 9.5f, 0.5f, 35f),  
        (115, 30, 25f, 5.5f, 2f, 15f)   
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
        if (aura < 5)
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
