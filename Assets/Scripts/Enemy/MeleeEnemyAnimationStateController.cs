using UnityEngine;

public class MeleeEnemyAnimationStateController : MonoBehaviour
{
    [SerializeField] GameObject legs;
    Animator legsAnimator;
    MeleeAI mai;
    void Start()
    {
        legsAnimator = legs.GetComponent<Animator>();
        mai = GetComponent<MeleeAI>();
    }

    // Update is called once per frame
    void Update()
    {
        if (mai.IsWalking)
        {
            legsAnimator.SetBool("IsWalking", true);
        }
        else
        {
            legsAnimator.SetBool("IsWalking", false);
        }
    }
}
