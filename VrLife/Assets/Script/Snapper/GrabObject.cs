using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabObject : MonoBehaviour
{
    XRPokeInteractor pokeInteractor;
    private bool grabbed;
    private SnapObject So;
    void OnEnable()
    {
        pokeInteractor = GetComponent<XRPokeInteractor>();
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
            So.grabbed = true;
            grabbed = true;
        }
        else
        {
            So.grabbed = false;
            grabbed = false;
            Debug.LogAssertion("No Snap Object Found !");
        }
    }
    
    public void RemoveTransform(SelectExitEventArgs args)
    {
        Transform obj = args.interactableObject.transform;
        if (grabbed)
        {
            FollowGrid.CeilVector(transform.position);
            SnapManager.Instance().targetSnapObject = null;
        }
    }
}
