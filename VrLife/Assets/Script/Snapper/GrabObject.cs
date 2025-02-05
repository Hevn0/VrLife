using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabObject : MonoBehaviour
{
    XRPokeInteractor pokeInteractor;
    private bool grabbed;
    void Start()
    {
        pokeInteractor = GetComponent<XRPokeInteractor>();
        pokeInteractor.selectEntered.AddListener(SetTransform);
        pokeInteractor.selectExited.AddListener(RemoveTransform);
    }

    private void OnDisable()
    {
        pokeInteractor.selectEntered.RemoveListener(SetTransform);
        pokeInteractor.selectExited.RemoveListener(RemoveTransform);
    }

    void SetTransform(SelectEnterEventArgs args)
    {
        Transform obj = args.interactableObject.transform;

        obj.TryGetComponent(out SnapObject found);
        
        if (found)
        {
            SnapManager.Instance().targetSnapObject = found;
            grabbed = true;
        }
        else
        {
            grabbed = false;
            Debug.LogAssertion("No Snap Object Found !");
        }
    }
    
    void RemoveTransform(SelectExitEventArgs args)
    {
        if (grabbed)
        {
            SnapManager.Instance().targetSnapObject = null;
        }
    }
}
