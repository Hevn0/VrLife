using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class SnapManager : MonoBehaviour
{
    private static SnapManager _instance;
    public SnapObject targetSnapObject;
    public SnapObject closestObject;
    public float snapToObjectDistance;
    public Vector3 closestPoint;
    private SnapObject lastSnapObject;
    private float distanceToClosestPoint;
    public Transform targetTransform;
    public float rayLength;
    public bool grabbing;
    private bool wasGrabbing;
    public FollowGrid fg;
    public float GridScale = 1;
    public float waitTime;
    
    
    public static SnapManager Instance()
    {
        if (_instance == null)
        {
            _instance = FindAnyObjectByType<SnapManager>();
        }
        return _instance;
    }
    
    public List<SnapObject> snapObjects;
    public GameObject debugObject;
    public List<GameObject> debugObjects;
    public LayerMask ObjectsLayer;
    void Start()
    {
        FindObjects();
        UpdatePositions();
        closestPoint = Vector3.zero;
    }

    [ContextMenu("Find Snap Objects")]
    void FindObjects()
    {
        snapObjects = FindObjectsByType<SnapObject>(FindObjectsSortMode.None).ToList();
    }

    public void OnGridSnap()
    {
        closestObject = GetClosestSnapObject();
        
        if (lastSnapObject != closestObject)
        {
            closestObject.updatePositions();
            DrawPos();
            lastSnapObject = closestObject;
        }
        closestPoint = GetClosestPoint(out distanceToClosestPoint);
    }

    [ContextMenu("Clean Debugs")]
    private void CleanDebugs()
    {
        for (int i = 0; i < debugObjects.Count; i++)
        {
            GameObject go = debugObjects[i];
            DestroyImmediate(go);
        }
        debugObjects.Clear();
    }

    [ContextMenu("Update Debugs")]
    private void UpdatePositions()
    {
        foreach (SnapObject so in snapObjects)
        {
            so.updatePositions();
        }
    }
    
    private void LateUpdate()
    {
        grabbing = targetTransform;
        if (targetSnapObject == null) return;
        
        fg.leader = targetSnapObject.transform;
        
        // if (grabbing)
        // {
        //     float dist = Vector3.Distance(targetTransform.position, closestPoint);
        //     targetSnapObject.transform.position = dist < (snapToObjectDistance * GridScale) ? closestPoint : targetTransform.position;
        //     wasGrabbing = true;
        // }
        UpdatePos();
    }

    private SnapObject GetClosestSnapObject()
    {
        SnapObject closestSo = snapObjects[0] != targetSnapObject ? snapObjects[0] : snapObjects[1];
        float minDist = Vector3.Distance(closestSo.transform.position, targetSnapObject.transform.position);
        
        foreach (SnapObject so in snapObjects)
        {
            if (so != targetSnapObject)
            {
                float dst = Vector3.Distance(so.transform.position, targetSnapObject.transform.position);
                if (dst < minDist)
                {
                    closestSo = so;
                    minDist = dst;
                }
            }
        }
        return closestSo;
    }
    
    private Vector3 GetClosestPoint(out float minDist)
    {
        Vector3 cp = closestObject.snapPoints[0];
        
        minDist = Vector3.Distance(closestObject.snapPoints[0], targetSnapObject.transform.position);
        
        foreach (Vector3 pos in closestObject.snapPoints)
        {
            float dst = Vector3.Distance(pos, targetSnapObject.transform.position);
            if (dst < minDist)
            {
                cp = pos;
                minDist = dst;
            }
        }
        return cp;
    }

    private void DrawPos()
    {
        CleanDebugs();
        foreach (Vector3 sp in closestObject.snapPoints)
        {
            GameObject o = Instantiate(debugObject, sp, Quaternion.identity);
            o.transform.localScale *= GridScale;
            debugObjects.Add(o);
        }
    }

    private void UpdatePos()
    {
        foreach (GameObject go in debugObjects)
        {
            bool active = Vector3.Distance(go.transform.position, targetSnapObject.transform.position) > .1f;
            go.SetActive(active);
        }
    }

    public void OnDeselect(SnapObject so)
    {
        fg.CeilGrid();
        OnGridSnap();
        so.transform.position = FollowGrid.CeilVector(fg.transform.position);
        RotateNearest(so.transform);
    }

    private void RotateNearest(Transform t)
    {
        Vector3 targetEuler = t.rotation.eulerAngles;
        
        targetEuler.x = Mathf.Round(targetEuler.x / 90f) * 90f;
        targetEuler.y = Mathf.Round(targetEuler.y / 90f) * 90f;
        targetEuler.z = Mathf.Round(targetEuler.z / 90f) * 90f;
        
        t.rotation = Quaternion.Euler(targetEuler);
    }
    // private void OnDrawGizmos()
    // {
    //     if (closestObject != null)
    //     {
    //         Gizmos.color = Color.green;
    //         Gizmos.DrawLine(targetSnapObject.transform.position, closestObject.transform.position);
    //         Gizmos.color = Color.red;
    //         Gizmos.DrawLine(targetSnapObject.transform.position, closestPoint);
    //     }
    // }
}
