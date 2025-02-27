using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    Transform player;
    Vector3 offset;    
    [SerializeField] float smoothSpeed = 0.125f;  

    void Start()
    {
        player = FindAnyObjectByType<PlayerMovement>().transform;
        offset = new Vector3(-16.50f, 15.00f, 16.50f); //transform.position - player.position;
        Debug.Log("nigga" + offset);
    }

    void LateUpdate()
    {
        Vector3 endPosition = player.position + offset;
        Vector3 smoothPosition = Vector3.Lerp(transform.position, endPosition, smoothSpeed);
        transform.position = smoothPosition;    
    }
}
