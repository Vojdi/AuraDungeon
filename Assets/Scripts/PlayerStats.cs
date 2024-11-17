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
    void Start()
    {
        range = 12f;
        movementSpeed = 5f;
        reloadRate = 1f;
        projectileSpeed = 10f;
    }
}
