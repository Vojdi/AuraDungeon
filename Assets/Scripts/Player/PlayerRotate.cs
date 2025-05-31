using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class PlayerRotate : MonoBehaviour
{
    [SerializeField] Transform lineRendererSpawnObject; 
    static Vector3 lookDirection;
    public static Vector3 LookDirection => lookDirection;
    LineRenderer lineRenderer;
    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 2;
        lineRenderer.enabled = false;
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        Ray ray = Camera.main.ScreenPointToRay(mousePosition);
        Plane groundPlane = new Plane(Vector3.up, new Vector3(0, lineRendererSpawnObject.position.y, 0));
        if (groundPlane.Raycast(ray, out float distanceToPlane))
        {
            Vector3 rayEnd = ray.GetPoint(distanceToPlane);
            Debug.DrawLine(ray.origin, rayEnd, Color.blue);
            Vector3 visualMousePos = new Vector3(rayEnd.x,transform.position.y , rayEnd.z);
            transform.LookAt(visualMousePos);
            ShowRange(visualMousePos);
        }
        if (Input.GetMouseButtonDown(1)) {
            lineRenderer.enabled = !lineRenderer.enabled;
        }
    }

    void ShowRange(Vector3 visualMousePos)
    {
        Vector3 direction = GetDirection(visualMousePos);
        Vector3 endPosition;
        float distanceToMouse = Vector3.Distance(lineRendererSpawnObject.position, visualMousePos);
        int layerMask = ~LayerMask.GetMask("Projectile");
        if (Physics.Raycast(lineRendererSpawnObject.position, direction, out RaycastHit hit, PlayerStats.Instance.Range, layerMask))
        {
            if (distanceToMouse < hit.distance)
            {
                endPosition = visualMousePos;
            }
            else
            {
                endPosition = hit.point;
            }
        }
        else
        { 
            if (distanceToMouse <= PlayerStats.Instance.Range)
            {
                endPosition = visualMousePos;
            }
            else
            {
                endPosition = lineRendererSpawnObject.position + direction * PlayerStats.Instance.Range;
            }
        }
        endPosition.y = lineRendererSpawnObject.position.y;
        lineRenderer.SetPosition(0, lineRendererSpawnObject.position);
        lineRenderer.SetPosition(1, endPosition);
    }
    Vector3 GetDirection(Vector3 VisualMousePos)
    {
        Vector3 direction = (VisualMousePos - lineRendererSpawnObject.position).normalized;
        direction.y = 0;
        lookDirection = direction;
        return direction;
    }
}
