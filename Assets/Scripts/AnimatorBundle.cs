using UnityEngine;

public class AnimatorBundle : MonoBehaviour
{
    [SerializeField] GameObject legs;
    [SerializeField] GameObject hands;

    public Animator GetLegsAnimator()
    {
        return legs.GetComponent<Animator>();
    }
    public Animator GetHandsAnimator()
    {
        return hands.GetComponent<Animator>();
    }
}
