using UnityEngine;

public class Projectile : MonoBehaviour
{
    Vector3 direction;
    Vector3 startPlayerPos;
    PlayerStats playerStats;
    float distanceTravelled;
    void Start()
    {
        direction = PlayerRotate.LookDirection;
        startPlayerPos = PlayerMovement.PlayerPosition;
        playerStats = FindAnyObjectByType<PlayerStats>();
        distanceTravelled = 0f;
    }
    void Update()
    {
        Travel();
        CheckForDistanceTravelled();
    }
    void Travel()
    {
        transform.Translate(direction * Time.deltaTime * playerStats.ProjectileSpeed);
    }
    void CheckForDistanceTravelled()
    {
        distanceTravelled = Vector3.Distance(transform.position, startPlayerPos);
        if (distanceTravelled >= playerStats.Range)
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
