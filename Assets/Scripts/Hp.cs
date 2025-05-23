using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Hp : MonoBehaviour
{
    protected int health;
    public int Health => health;
    public int MaxHealth;

    private Color flashColor = Color.red;
    private List<Material> materials = new List<Material>();
    private List<Color> originalColors = new List<Color>();


    protected virtual void Start()
    {
        health = MaxHealth;
        foreach (var renderer in GetComponentsInChildren<Renderer>())
        {
            var mat = renderer.material;
            materials.Add(mat);
            originalColors.Add(mat.color);
        }
    }
    protected void Flash()
    {
        StopAllCoroutines();
        StartCoroutine(FlashRoutine());
    }
    IEnumerator FlashRoutine()
    {
        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].color = flashColor;
        }

        yield return new WaitForSeconds(0.2f);

        for (int i = 0; i < materials.Count; i++)
        {
            materials[i].color = originalColors[i];
        }
    }

    public virtual void DoDmg(int Dmg)
    {
        if(Dmg > 0)
        {
            Flash();
        }
        health -= Dmg;
        if (health <= 0)
        {
            Die();    
        }
    }
    protected abstract void Die();
   
}
