using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    protected int health;
    public int Health => health;
    public int MaxHealth;

    protected virtual void Start()
    {
        health = MaxHealth;
    }
    
    public virtual void DoDmg(int Dmg)
    {
        health -= Dmg;
        if (health <= 0)
        {
            Die();    
        }
    }
    protected abstract void Die();
   
}
