
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<Projectile> projectiles = new List<Projectile>();  
    private void Start()
    {
        for (int i = 0; i < 20; i++) { 
            var projectile = Instantiate(GetComponent<PlayerAttack>().ProjectilePrefab).GetComponent<Projectile>();
            projectiles.Add(projectile);
            projectile.gameObject.SetActive(false);
        }
    }
    
}
