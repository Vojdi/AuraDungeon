using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Transform capsule;
    void Start()
    {
        
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;       
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        if (Physics.Raycast(ray, out  RaycastHit hit, 100f))
        {
            Debug.Log("Hit: " + hit.collider.gameObject.name);
            Debug.DrawLine(ray.origin, hit.point, Color.red);
            
            capsule.LookAt(new Vector3(hit.point.x, 1, hit.point.z));
        }
        else
        {
            Debug.Log("Raycast didn't hit anything.");
        }
    }
}
