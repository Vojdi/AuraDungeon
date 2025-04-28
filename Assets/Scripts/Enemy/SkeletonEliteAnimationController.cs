using UnityEngine;

public class SkeletonEliteAnimationController : EnemyAnimationStateController
{
    SkeletonEliteAI ai;
    override protected void Start()
    {
         base.Start();
         ai = GetComponent<SkeletonEliteAI>();
    }
    public override void InitiateAttack()
    {
        base.InitiateAttack();
        if (SkeletonEliteAI.AttackType == 0)
        {
            handsAnimator.SetBool("IsAttacking1", true);
        }if (SkeletonEliteAI.AttackType == 1) {
            handsAnimator.SetBool("IsAttacking2", true);
        }
        
    }
    protected override void Update()
    {
        RefreshValues();
        if (ai.IsWalking)
        {
            MovementIsWalking();
        }
        else
        {
            MovementNotWalking();
        }
    }
}
