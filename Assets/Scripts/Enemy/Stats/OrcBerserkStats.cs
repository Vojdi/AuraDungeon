using UnityEngine;

public class OrcBerserkStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 70;
        sightRange = 15;
        auraToughness = 8;
        movementSpeed = 3;
        reloadTime = 1f;
        reach = 6f;
        damage = 40;
    }
}
