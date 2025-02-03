using System;
using UnityEngine;

public class Gridgeneration : MonoBehaviour
{
    public GameObject gridObject;
    public int gridSize;
    public Transform target;
    public Material mat;
    
    
    private void OnEnable()
    {
        GenerateGrid();
    }

    void GenerateGrid()
    {
        for (int z = -gridSize; z < gridSize + 1; z++)
        {
            for (int y = -gridSize; y < gridSize+ 1; y++)
            {
                for (int x = -gridSize; x < gridSize+ 1; x++)
                {
                    Instantiate(gridObject, new Vector3(target.position.x + x,target.position.y + y,target.position.z + z), Quaternion.identity,target);
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
