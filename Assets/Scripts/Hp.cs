using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    private int health;
    public int Health => health;
    public int MaxHealth;

    protected virtual void Start()
    {
        health = MaxHealth;
    }
    
    public void DoDmg(int Dmg)
    {
        health -= Dmg;
        if (health <= 0)
        {
            Die();    
        }
    }
    protected abstract void Die();
}
