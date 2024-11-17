using System.Collections;
using System.Collections.Generic;
using UnityEditor.PackageManager;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    PlayerStats playerStats;
    CharacterController characterController;

    static Vector3 playerPosition;
    public static Vector3 PlayerPosition => playerPosition;
    Vector3 moveDirection;

    
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        characterController = GetComponent<CharacterController>();
    }
    void Update()
    {
        GetDirection();
        ApplyGravity();
        characterController.Move(moveDirection * Time.deltaTime * playerStats.MovementSpeed);
        playerPosition = transform.position;
    }

    void GetDirection()
    {
        float moveX = Input.GetAxis("Horizontal");
        float moveZ = Input.GetAxis("Vertical");

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;

        forward.y = 0f;
        right.y = 0f;

        moveDirection = (right * moveX + forward * moveZ);
    }
    void ApplyGravity()
    {
        float gravity = -9.81f;
        float velocity;
        float gravityMultiplier = 5;

        velocity = gravity * gravityMultiplier * Time.deltaTime;

        moveDirection.y = velocity;
    }
    
}
