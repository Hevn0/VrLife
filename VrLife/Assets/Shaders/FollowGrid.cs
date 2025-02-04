using System;
using UnityEngine;
using UnityEngine.Serialization;

public class FollowGrid : MonoBehaviour
{
    private static readonly int TargetPos = Shader.PropertyToID("_targetPos");
    public GameObject gridObject;
    public int gridSize;
    public float gridScale;
    public Transform follower,leader;
    public Material mat;
    public float snapDistance;
    
    
    private void OnEnable()
    {
        GenerateGrid();
    }

    private void Update()
    {
        if (Vector3.Distance(follower.position,leader.position) > snapDistance)
        {
            CeilGrid();
        }
    }

    public void CeilGrid()
    {
        mat.SetVector(TargetPos,leader.position);
        follower.position = CeilVector(leader.position);
        SnapManager.Instance().OnGridSnap();
    }

    public static Vector3 CeilVector(Vector3 vector)
    {
        Vector3 v = vector;
        v = new Vector3(Mathf.Round(v.x), Mathf.Round(v.y), Mathf.Round(v.z));
        return v;
    }

    void GenerateGrid()
    {
        for (int z = -gridSize; z < gridSize + 1; z++)
        {
            for (int y = -gridSize; y < gridSize+ 1; y++)
            {
                for (int x = -gridSize; x < gridSize+ 1; x++)
                {
                    GameObject o = Instantiate(gridObject, new Vector3(follower.position.x + (x * gridScale),follower.position.y + y* gridScale,follower.position.z + z* gridScale), Quaternion.identity,follower);
                    o.transform.localScale = new Vector3(gridScale, gridScale, gridScale);;
                }
            }
        }
    }

    private void OnDisable()
    {
        if (transform.childCount != 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(i).gameObject);
            }
        }
    }
}
