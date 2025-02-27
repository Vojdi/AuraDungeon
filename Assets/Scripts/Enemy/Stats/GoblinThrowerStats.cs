using Unity.VisualScripting;
using UnityEngine;

public class GoblinThrowerStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 30;
        sightRange = 25;
        auraToughness = 5;
        movementSpeed = 9;
        reloadTime = 2f;
        reach = 20;
        damage = 10;
        projectileSpeed = 20;
        projectileRange = 20;
    }
}
