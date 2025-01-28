using Unity.VisualScripting;
using UnityEngine;

public class GoblinThrowerStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 40;
        sightRange = 20;
        auraToughness = 5;
        movementSpeed = 6;
        reloadTime = 2f;
        reach = 10;
        damage = 10;
        projectileSpeed = 20;
        projectileRange = 20;
    }
}
