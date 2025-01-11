using System;
using UnityEngine;

public class MeleeEnemyAnimationStateController : MonoBehaviour
{
    [SerializeField] GameObject legs;
    [SerializeField] GameObject hands;
    Animator legsAnimator;
    Animator handsAnimator;
    MeleeAI mai;
    EnemyStats es;
    void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        handsAnimator = hands.GetComponent<Animator>();
        mai = GetComponent<MeleeAI>();
        es = GetComponent<EnemyStats>();
    }
    void Update()
    {

        ApplyMovementSpeedMultiplier();
        if (mai.IsWalking)
        {
            legsAnimator.SetBool("IsWalking", true);
            handsAnimator.SetBool("IsWalking", true);

        }
        else
        {
            legsAnimator.SetBool("IsWalking", false);
            handsAnimator.SetBool("IsWalking", false);
        }
        ApplyAttackSpeedMultiplier();
        if (mai.IsAttacking)
        {
            handsAnimator.SetBool("IsAttacking", true);
        }
        else
        {
            handsAnimator.SetBool("IsAttacking", false);
        }
    }

    void ApplyAttackSpeedMultiplier()
    {
        handsAnimator.SetFloat("AttackSpeedMultiplier", 1 / es.ReloadTime);
    }

    void ApplyMovementSpeedMultiplier()
    {
        if (handsAnimator.GetFloat("MovementSpeedMultiplier") != es.MovementSpeed * 5)
        {
            handsAnimator.SetFloat("MovementSpeedMultiplier", es.MovementSpeed / 5);
            legsAnimator.SetFloat("MovementSpeedMultiplier", es.MovementSpeed / 5);
        }
    }
}
