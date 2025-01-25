using System;
using UnityEngine;

public class EnemyAnimationStateController : AnimationStateController
{
    EnemyAI eAI;
    EnemyStats eS;
    override protected void Start()
    {
        base.Start();
        eAI = GetComponent<EnemyAI>();
        eS = GetComponent<EnemyStats>();
    }
    void Update()
    {
        RefreshValues();
        if (eAI.IsWalking)
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
        movementSpeed = eS.MovementSpeed;
        reloadRate = eS.ReloadTime;
    }
}
