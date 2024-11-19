using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    Vector3 startPlayerPos;
    float distanceTravelled;
    void Start()
    {
        direction = PlayerRotate.LookDirection;
        startPlayerPos = PlayerMovement.PlayerPosition;
        distanceTravelled = 0f;
    }
    void Update()
    {
        Travel();
        CheckForDistanceTravelled();
    }
    void Travel()
    {
        transform.Translate(direction * Time.deltaTime * PlayerStats.Instance.ProjectileSpeed);
    }
    void CheckForDistanceTravelled()
    {
        distanceTravelled = Vector3.Distance(transform.position, startPlayerPos);
        if (distanceTravelled >= PlayerStats.Instance.Range)
        {
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.root.gameObject.GetComponent<PlayerStats>() == null)
        {
            Destroy(gameObject);   
        }
    }
}
