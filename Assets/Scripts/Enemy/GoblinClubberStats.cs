using UnityEngine;

public class GoblinClubberStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 50;
        sightRange = 15;
        auraToughness = 5;
        movementSpeed = 6;
        reloadTime = 2f;
        reach = 3f;
        damage = 20;
    }
}
