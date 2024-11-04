using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    static Vector3 playerPosition;
    public static Vector3 PlayerPosition => playerPosition;
    
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
    }
    void Update()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0f;  
        right.y = 0f;
        
        Vector3 moveDirection = (right * moveX + forward * moveZ);
        transform.Translate(moveDirection * playerStats.MovementSpeed * Time.deltaTime);
        playerPosition = transform.position;
    }
}
