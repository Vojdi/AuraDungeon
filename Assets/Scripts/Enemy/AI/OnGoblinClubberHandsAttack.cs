using UnityEngine;

public class OnGoblinClubberHandsAttack : MonoBehaviour
{
    [SerializeField] Collider col;
    Animator handsAnimator;
    

    private void Start()
    {
        handsAnimator = GetComponent<Animator>();
    }
    void EnableCollider()
    {
        col.enabled = true;
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
        col.enabled = false;
        
    }
    void EndAnimation()
    {
        handsAnimator.SetBool("IsAttacking", false);
    }
    
}
