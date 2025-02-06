using System;
using System.Collections.Generic;
using UnityEngine;

public class SnapObject : MonoBehaviour
{
    public List<Vector3> snapPoints;
    private float rayLength;
    public bool grabbed = false;

    private void Start()
    {
        SnapManager.Instance().snapObjects.Add(this);
        updatePositions();
    }

    [ContextMenu("Check Objects")]
    public void updatePositions()
    {
        Vector3[] directions = {Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back};
        snapPoints = new List<Vector3>();
        float gridScale = SnapManager.Instance().GridScale;
        rayLength = SnapManager.Instance().rayLength * gridScale;

        SnapManager manager = SnapManager.Instance();
        
        foreach (Vector3 target in directions)
        {
            Ray ray = new Ray(transform.position, target);

            if (Physics.Raycast(ray, rayLength, manager.ObjectsLayer)) continue;
            
            snapPoints.Add(transform.position + (target * gridScale));
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        rayLength = SnapManager.Instance().rayLength * SnapManager.Instance().GridScale;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back * rayLength);
    }
}
