using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CubeManager : MonoBehaviour
{
    [Header("Settings")] 
    [SerializeField, Range(0, 1)] private float distanceToSpawn;
    
    [System.Serializable]
    public class SpawnPoint
    {
        public Transform point; 
        public CubeType cubeType; 
        [HideInInspector] public GameObject currentCube; 
        public int currentCount; 
        public Text cubeCounterText;
    }

    public List<SpawnPoint> spawnPoints; 

    private void Start()
    {
        foreach (var spawn in spawnPoints)
        {
            SpawnCube(spawn);
            UpdateCubeCountUI(spawn);
        }
    }

    private void Update()
    {
        foreach (var spawn in spawnPoints)
        {
            if (spawn.currentCube != null && Vector3.Distance(spawn.currentCube.transform.position, spawn.point.position) > distanceToSpawn)
            {
                spawn.currentCube = null;
                SpawnCube(spawn);
                UpdateCubeCountUI(spawn);
            }
        }
    }

    private void SpawnCube(SpawnPoint spawn)
    {
        if (spawn.currentCount < spawn.cubeType.maxCount)
        {
            spawn.currentCube = Instantiate(spawn.cubeType.cubePrefab, spawn.point.position, Quaternion.identity);
            spawn.currentCount++;
        }
    }
    
    private void UpdateCubeCountUI(SpawnPoint spawn)
    {
        if (spawn.cubeCounterText != null)
        {
            int cubesRestants = spawn.cubeType.maxCount - spawn.currentCount;
            spawn.cubeCounterText.text = cubesRestants.ToString();
        }
    }
    
}
