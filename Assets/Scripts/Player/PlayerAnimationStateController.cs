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
        handsAnimator.SetBool("IsAttacking", true);
    }
}
