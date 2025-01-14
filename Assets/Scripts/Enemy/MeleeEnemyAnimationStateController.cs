using System;
using UnityEngine;

public class MeleeEnemyAnimationStateController : AnimationStateController
{
    MeleeAI mai;
    EnemyStats es;
    override protected void Start()
    {
        base.Start();
        mai = GetComponent<MeleeAI>();
        es = GetComponent<EnemyStats>();
    }
    void Update()
    {
        RefreshValues();
        if (mai.IsWalking)
        {
            MovementIsWalking();

        }
        else
        {
            MovementNotWalking();
        }
    }
    override protected void RefreshValues()
    {
        movementSpeed = es.MovementSpeed;
        reloadRate = es.ReloadTime;
    }
}
