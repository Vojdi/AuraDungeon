using UnityEngine;

public class OnEnemyHandsAttack : MonoBehaviour
{
    [SerializeField] Collider col;
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
            col.enabled = false;
        }
    }
    void EndAttack()
    {
        col.enabled = false;
        transform.root.gameObject.GetComponent<MeleeAI>().StopAttacking();
    }
}
