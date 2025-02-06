using System;
using UnityEngine;

public class SpawnTrigger : MonoBehaviour
{
    private static readonly int CheckpointOn = Shader.PropertyToID("_CheckpointON");

    public enum TriggerType
    {
        CheckPoint1,
        CheckPoint2,
        CheckPoint3,
        fin
    }
    public MeshRenderer r;
    private MaterialPropertyBlock mp;
    public TriggerType triggerType;

    private void OnEnable()
    {
        mp = new MaterialPropertyBlock();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Bille"))
        {
            r.GetPropertyBlock(mp);
            mp.SetInt(CheckpointOn,1);
            r.SetPropertyBlock(mp);
            
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
                    break;
            }
        }
    }

    private void OnDisable()
    {
        r.GetPropertyBlock(mp);
        mp.SetInt(CheckpointOn,0);
        r.SetPropertyBlock(mp);
    }
}
