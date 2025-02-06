using System;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    public enum TriggerType
    {
        CheckPoint1,
        CheckPoint2,
        CheckPoint3,
        fin
    }

    public TriggerType triggerType;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            switch (triggerType)
            {
                case TriggerType.CheckPoint1:
                    SpawnPoint.instance.UnlockCheckPoint1();
                    break;
                case TriggerType.CheckPoint2:
                    SpawnPoint.instance.UnlockCheckPoint2();
                    break;
                case TriggerType.CheckPoint3:
                    SpawnPoint.instance.UnlockCheckPoint3();
                    break;
                case TriggerType.fin:
                    // Faire une fin 
                    break;
            }
        }
    }
}
