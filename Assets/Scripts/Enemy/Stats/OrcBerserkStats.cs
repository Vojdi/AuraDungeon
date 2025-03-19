using UnityEngine;

public class OrcBerserkStats : EnemyStats
{
    private void Awake()
    {
        maxHp = 80;
        sightRange = 18;
        auraToughness = 8;
        movementSpeed = 3;
        reloadTime = 1f;
        reach = 6f;
        damage = 30;
        dangerValue = 3;
    }
}
