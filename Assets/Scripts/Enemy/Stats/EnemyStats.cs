using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    [SerializeField]
    protected int maxHp;
    public int MaxHp => maxHp;

    [SerializeField]
    protected int auraToughness;
    public int AuraToughness => auraToughness;

    [SerializeField]
    protected int sightRange;
    public int SightRange => sightRange;

    [SerializeField]
    protected float movementSpeed;
    public float MovementSpeed => movementSpeed;

    [SerializeField]
    protected float reloadTime;
    public float ReloadTime => reloadTime;

    [SerializeField]
    protected float reach;
    public float Reach => reach;

    [SerializeField]
    protected int damage;
    public int Damage => damage;

    [SerializeField]
    protected int dangerValue;
    public int DangerValue => dangerValue;

    // Ranged enemy only
    [SerializeField]
    protected float projectileSpeed;
    public float ProjectileSpeed => projectileSpeed;

    [SerializeField]
    protected float projectileRange;
    public float ProjectileRange => projectileRange;

    private void Awake()
    {
        int enhancer = GameManager.EnemyEnhancer;

        maxHp += Mathf.RoundToInt(maxHp * 0.3f * enhancer);     // +20% per enhancer
        sightRange += Mathf.RoundToInt(sightRange * 0.15f * enhancer); // +15% per enhancer
        movementSpeed += movementSpeed * 0.15f * enhancer;  // floats are fine
        reloadTime -= reloadTime * 0.15f * enhancer;        // floats are fine
        damage += Mathf.RoundToInt(damage * 0.1f * enhancer);   // +20% per enhancer
        projectileSpeed += projectileSpeed * 0.10f * enhancer;
        projectileRange += projectileRange * 0.10f * enhancer;
    }


}
    