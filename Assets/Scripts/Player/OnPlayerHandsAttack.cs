using UnityEngine;

public class OnPlayerHandsAttack : MonoBehaviour
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
        playerAttack.Reload();
        handsAnimator.SetBool("IsAttacking", false);
    }
}
