
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ObjectPool : MonoBehaviour
{
    public List<Projectile> projectiles = new List<Projectile>();  
    private void Start()
    {
        var projectile = GetComponent<PlayerAttack>().ProjectilePrefab.GetComponent<Projectile>();
        for (int i = 0; i < 7; i++) {
            var prj = Instantiate(projectile, Waste.Instance.transform);
            projectiles.Add(prj);
            prj.gameObject.SetActive(false);
        }
    }
    
}
