using UnityEngine;

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
    public float ReloadRate => reloadTime;

    float projectileSpeed;
    public float ProjectileSpeed => projectileSpeed;

    int aura;
    public int Aura => aura;    

    private static PlayerStats instance;
    public static PlayerStats Instance => instance;
    void Awake()
    {
        instance = this;
        maxHp = 100;
        damage = 10;
        range = 20f;
        movementSpeed = 10f;
        reloadTime = 1f;
        projectileSpeed = 20f;
        aura = 0;
    }
}
