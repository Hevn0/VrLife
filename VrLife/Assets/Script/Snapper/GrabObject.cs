using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabObject : MonoBehaviour
{
    private bool grabbed;
    private SnapObject So;
    void OnEnable()
    {
        So = GetComponent<SnapObject>();
        // pokeInteractor.selectEntered.AddListener(SetTransform);
        // pokeInteractor.selectExited.AddListener(RemoveTransform);
    }

    private void OnDisable()
    {
        // pokeInteractor.selectEntered.RemoveListener(SetTransform);
        // pokeInteractor.selectExited.RemoveListener(RemoveTransform);
    }

    public void SetTransform(SelectEnterEventArgs args)
    {
        Transform obj = args.interactableObject.transform;

        obj.TryGetComponent(out SnapObject found);
        
        if (found)
        {
            SnapManager.Instance().targetSnapObject = found;
        }
        else
        {
            Debug.LogAssertion("No Snap Object Found !");
        }
    }
    
    public void RemoveTransform(SelectExitEventArgs args)
    {
        Transform obj = args.interactableObject.transform;
        Invoke(nameof(Wait),SnapManager.Instance().waitTime);
    }

    private void Wait()
    {
        SnapManager.Instance().OnDeselect(So);
        SnapManager.Instance().targetSnapObject = null;
    }
}
