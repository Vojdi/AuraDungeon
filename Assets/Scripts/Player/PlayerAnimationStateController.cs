using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    [SerializeField] GameObject legs;
    [SerializeField] GameObject hands;
    Animator legsAnimator;
    Animator handsAnimator;
    void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        handsAnimator = hands.GetComponent<Animator>();
    }
    void Update()
    {
        ApplyMovementSpeedMultiplier();
        if (PlayerMovement.IsWalking)
        {
            legsAnimator.SetBool("IsWalking", true);
            handsAnimator.SetBool("IsWalking", true);
        }
        else
        {
            legsAnimator.SetBool("IsWalking", false);
            handsAnimator.SetBool("IsWalking", false);
        }
    }
    public void InitiateAttack()
    {
        ApplyAttackSpeedMultiplier();
        handsAnimator.SetBool("IsAttacking", true);
    }
    private void ApplyMovementSpeedMultiplier()
    {
        if (handsAnimator.GetFloat("MovementSpeedMultiplier") != PlayerStats.Instance.MovementSpeed * 5)
        {
            handsAnimator.SetFloat("MovementSpeedMultiplier", PlayerStats.Instance.MovementSpeed / 5);
            legsAnimator.SetFloat("MovementSpeedMultiplier", PlayerStats.Instance.MovementSpeed / 5);
        }
    }
    private void ApplyAttackSpeedMultiplier()
    {
        handsAnimator.SetFloat("AttackSpeedMultiplier", 1 / PlayerStats.Instance.ReloadRate);
    }
}
