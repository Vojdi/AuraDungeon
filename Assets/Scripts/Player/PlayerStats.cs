using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    int maxHp;
    public int MaxHp => maxHp;
    float range;
    public float Range => range;

    float movementSpeed;
    public float MovementSpeed => movementSpeed;

    float reloadTime;
    public float ReloadRate => reloadTime;

    float projectileSpeed;
    public float ProjectileSpeed => projectileSpeed;    

    private static PlayerStats instance;
    public static PlayerStats Instance => instance;
    void Start()
    {
        instance = this;
        maxHp = 100;
        range = 15f;
        movementSpeed = 5f;
        reloadTime = 1;
        projectileSpeed = 20f;
    }
}
