using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Transform playerGraphics;
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, playerGraphics.position.y, 0));
        if (groundPlane.Raycast(ray, out float distanceToPlane))
        {
                Vector3 rayEnd = ray.GetPoint(distanceToPlane);
                Debug.DrawLine(ray.origin, rayEnd, Color.blue);
                playerGraphics.LookAt(new Vector3(rayEnd.x, playerGraphics.position.y, rayEnd.z));
        }
    }
}
