using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    protected int health;
    public int Health => health;
    protected int maxHealth;

    protected virtual void Start()
    {
        health = maxHealth;
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
