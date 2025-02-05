using UnityEngine;

[CreateAssetMenu(fileName = "CubeType", menuName = "Scriptable Objects/CubeType")]
public class CubeType : ScriptableObject
{
    public GameObject cubePrefab; 
    public int maxCount;
}
