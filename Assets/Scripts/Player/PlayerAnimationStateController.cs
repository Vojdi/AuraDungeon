using UnityEngine;

public class PlayerAnimationStateController : MonoBehaviour
{
    [SerializeField] GameObject legs;
    Animator legsAnimator;
    void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
    }

    
    void Update()
    {
        if (PlayerMovement.IsWalking)
        {
            legsAnimator.SetBool("IsWalking", true);
        }
        else
        {
            legsAnimator.SetBool("IsWalking", false);
        }
    }
}
