using UnityEngine;
using UnityEngine.Rendering;

public class AnimationStateController : MonoBehaviour
{
    [SerializeField] protected GameObject legs;
    [SerializeField] protected GameObject hands;
    protected Animator legsAnimator;
    protected Animator handsAnimator;
    protected float movementSpeed;
    protected float reloadRate;

    protected virtual void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        handsAnimator = hands.GetComponent<Animator>();
    }
    protected virtual void RefreshValues()
    {

    }
    private void ApplyMovementSpeedMultiplier()
    {
        if (handsAnimator.GetFloat("MovementSpeedMultiplier") != movementSpeed * 5)
        {
            handsAnimator.SetFloat("MovementSpeedMultiplier", movementSpeed / 5);
            legsAnimator.SetFloat("MovementSpeedMultiplier", movementSpeed / 5);
        }
    }
    private void ApplyAttackSpeedMultiplier()
    {
        handsAnimator.SetFloat("AttackSpeedMultiplier", 1 / reloadRate);
        legsAnimator.SetFloat("AttackSpeedMultiplier", 1 / reloadRate);
    }
    protected void MovementIsWalking()
    {
        ApplyMovementSpeedMultiplier();
        legsAnimator.SetBool("IsWalking", true);
        handsAnimator.SetBool("IsWalking", true);
    }
    protected void MovementNotWalking()
    {
        legsAnimator.SetBool("IsWalking", false);
        handsAnimator.SetBool("IsWalking", false);
    }
    public void InitiateAttack()
    {
        ApplyAttackSpeedMultiplier();
        handsAnimator.SetBool("IsAttacking", true);
        legsAnimator.SetBool("IsAttacking", true);
    }
}
