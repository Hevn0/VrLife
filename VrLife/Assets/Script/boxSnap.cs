using System;
using UnityEngine;

public class boxSnap : MonoBehaviour
{
    public float rayLength = 1.1f;
    public LayerMask cubeLayer; 
    
    private void Update()
    {
        CheckAndSnap();
    }

    public void CheckAndSnap()
    {
        Vector3[] directions = { Vector3.up, Vector3.down, Vector3.left, Vector3.right, Vector3.forward, Vector3.back };
        float cubeSize = transform.localScale.x; 

        foreach (Vector3 target in directions)
        {
            Ray ray = new Ray(transform.position, target);

            if (Physics.Raycast(ray, out RaycastHit hit, rayLength, cubeLayer))
            {
                Vector3 targetPosition = hit.transform.position - target * (cubeSize / 2 + hit.collider.bounds.extents.x);
                transform.position = targetPosition;
                break; 
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.down * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.left * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.right * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.forward * rayLength);
        Gizmos.DrawLine(transform.position, transform.position + Vector3.back * rayLength);
    }
}
