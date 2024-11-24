using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    float range;
    public float Range => range;

    float movementSpeed;
    public float MovementSpeed => movementSpeed;

    float reloadRate;
    public float ReloadRate => reloadRate;

    float projectileSpeed;
    public float ProjectileSpeed => projectileSpeed;    

    private static PlayerStats instance;
    public static PlayerStats Instance => instance;
    void Start()
    {
        instance = this;
        range = 20f;
        movementSpeed = 5f;
        reloadRate = 1f;
        projectileSpeed = 10f;
    }
}
