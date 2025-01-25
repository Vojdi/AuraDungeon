using UnityEngine;

public class GoblinClubberStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 40;
        sightRange = 15;
        auraToughness = 5;
        movementSpeed = 6;
        reloadTime = 2f;
        reach = 3.5f;
        damage = 20;
    }
}
