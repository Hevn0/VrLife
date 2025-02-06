using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    [Header("CheckPoint1")]
    public GameObject CheckPoint2;
    
    [Header("CheckPoint2")]
    public GameObject CheckPoint4;
    
    [Header("CheckPoint3")]
    public GameObject CheckPoint6;

    public static SpawnPoint instance;

    private void Awake()
    {
        instance = this;
    }
    
    public void UnlockCheckPoint1()
    {
        CheckPoint2.SetActive(false);
    }
    
    public void UnlockCheckPoint2()
    {
        CheckPoint4.SetActive(false);
    }
    
    public void UnlockCheckPoint3()
    {
        CheckPoint6.SetActive(false);
    }

    public void ResetCheckPoint()
    {
        CheckPoint2.SetActive(true);
        CheckPoint4.SetActive(true);
        CheckPoint6.SetActive(true);
    }
}
