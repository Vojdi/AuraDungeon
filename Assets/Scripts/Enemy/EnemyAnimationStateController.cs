using System;
using UnityEngine;

public class EnemyAnimationStateController : AnimationStateController
{
    [SerializeField] protected GameObject legs;
    [SerializeField] protected GameObject hands;
    EnemyAI eAI;
    EnemyStats eS;
    protected virtual void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        handsAnimator = hands.GetComponent<Animator>();
        eAI = GetComponent<EnemyAI>();
        eS = GetComponent<EnemyStats>();
    }
    protected virtual void Update()
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
