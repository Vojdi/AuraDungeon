using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float moveSpeed = 5f;  
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;  
        right.y = 0f;
        
        Vector3 moveDirection = (right * moveX + forward * moveZ);
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);
    }
}
