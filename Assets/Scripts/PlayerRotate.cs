using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Transform playerGraphics;
    [SerializeField] Transform lineRendererSpawnPosition; //pozice odkud pujde liniRenderer

    static Vector3 lookDirection;
    public static Vector3 LookDirection => lookDirection;
    
    LineRenderer lineRenderer;
    PlayerStats playerStats;
    private void Start()
    {
        playerStats = GetComponent<PlayerStats>();
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, playerGraphics.position.y, 0));
        if (groundPlane.Raycast(ray, out float distanceToPlane))
        {
                Vector3 rayEnd = ray.GetPoint(distanceToPlane);
                Debug.DrawLine(ray.origin, rayEnd, Color.blue);
                Vector3 visualMousePos = new Vector3(rayEnd.x, playerGraphics.position.y, rayEnd.z);
                playerGraphics.LookAt(visualMousePos);
                ShowRange(visualMousePos, GetDirection(visualMousePos));
        }
       

    }

    void ShowRange(Vector3 visualMousePos, Vector3 direction)
    {
        float distance = Vector3.Distance(transform.position, visualMousePos);
        Vector3 endPosition;
        if (distance <= playerStats.Range)
        {
            endPosition = visualMousePos;
        }
        else
        {
            endPosition = transform.position + direction * playerStats.Range;
        }
        lineRenderer.SetPosition(0, lineRendererSpawnPosition.position);
        lineRenderer.SetPosition(1, endPosition);
        
    }
    Vector3 GetDirection(Vector3 VisualMousePos)
    {
        Vector3 direction = (VisualMousePos - transform.position).normalized;
        lookDirection = direction;
        return direction;
    }
}
