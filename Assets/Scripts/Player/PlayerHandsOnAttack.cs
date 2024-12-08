using UnityEngine;

public class PlayerHandsOnAttack : MonoBehaviour
{
    PlayerAttack playerAttack;

    Animator handsAnimator;
    private void Start()
    {
        playerAttack = transform.root.gameObject.GetComponent<PlayerAttack>();
        handsAnimator = GetComponent<Animator>();
    }
    void OnAnimationAttack()
    {
        playerAttack.Attack();
    }
    void OnAnimationEnd()
    {
        handsAnimator.SetBool("IsAttacking", false);
    }
}
