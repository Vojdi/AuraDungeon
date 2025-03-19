using Unity.VisualScripting;
using UnityEngine;

public class SkeletonArcherStats : EnemyStats 
{
    private void Awake()
    {
        maxHp = 50;
        sightRange = 35;
        auraToughness = 8;
        movementSpeed = 7;
        reloadTime = 3f;
        reach = 30;
        damage = 40;
        projectileSpeed = 50;
        projectileRange = 30;
        dangerValue = 3;
    }
}
