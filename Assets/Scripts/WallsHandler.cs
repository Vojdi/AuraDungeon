using UnityEngine;

public class WallsHandler : MonoBehaviour
{
    [SerializeField] GameObject walls;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<PlayerMovement>() != null)
        {
            ActivateWalls();
            GetComponent<Collider>().enabled = false;
            GameManager.Instance.DestroyPrevRoom();
            GameManager.Instance.SpawnEnemies();
        }
    }
    public void ActivateWalls()
    {
        foreach (Transform child in walls.transform) { 
            child.gameObject.SetActive(true);
            
        }
    }
    public void DeactivateWalls()
    {
        foreach (Transform child in walls.transform)
        {
            child.gameObject.SetActive(false);
        }
    }
    public void DeactivateCollider()
    {
        GetComponent<Collider>().enabled = false;
    }
}
