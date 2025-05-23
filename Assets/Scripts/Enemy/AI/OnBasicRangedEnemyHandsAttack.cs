using UnityEngine;

public class OnBasicRangedEnemyHandsAttack : MonoBehaviour
{
    RangedEnemyAttack rEAttack;
    Animator handsAnimator;
    private void Start()
    {
        rEAttack = transform.root.GetComponent<RangedEnemyAttack>();   
        handsAnimator = GetComponent<Animator>();
    }
    void OnAnimationAttack()
    {
        rEAttack.Attack();
    }
    void OnAnimationEnd()
    {
        handsAnimator.SetBool("IsAttacking", false);
    }
}
