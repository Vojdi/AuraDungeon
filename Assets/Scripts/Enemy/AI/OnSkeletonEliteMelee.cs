using UnityEngine;

public class OnSkeletonEliteMelee : MonoBehaviour
{
    [SerializeField] Collider [] cols;
    Animator handsAnimator;


    private void Start()
    {
        handsAnimator = GetComponent<Animator>();
    }
    void EnableCollider()
    {
        foreach (Collider col in cols)
        {
            col.enabled = true;
        }
    }
    void OnTriggerEnter(Collider other)
    {
        var php = other.gameObject.GetComponent<PlayerHp>();
        if (php != null)
        {

            php.DoDmg(transform.root.gameObject.GetComponent<EnemyStats>().Damage);
            EndAttack();
        }
    }
    void EndAttack()
    {
        foreach(Collider col in cols)
        {
            col.enabled = false;
        }
        

    }
    void EndAnimation()
    {
        handsAnimator.SetBool("IsAttacking", false);
        handsAnimator.SetBool("IsAttacking1", false);
    }
}
