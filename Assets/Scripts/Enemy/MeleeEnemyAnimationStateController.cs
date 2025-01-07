using UnityEngine;

public class MeleeEnemyAnimationStateController : MonoBehaviour
{
    [SerializeField] GameObject legs;
    [SerializeField] GameObject hands;
    Animator legsAnimator;
    Animator handsAnimator;
    MeleeAI mai;
    void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        handsAnimator = hands.GetComponent<Animator>();
        mai = GetComponent<MeleeAI>();
    }
    void Update()
    {
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
    }
}
