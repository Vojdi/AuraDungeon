using UnityEngine;

public class Bilboard : MonoBehaviour
{
    void Update()
    {
        transform.LookAt(transform.position + Camera.main.transform.forward);     
    }
}
