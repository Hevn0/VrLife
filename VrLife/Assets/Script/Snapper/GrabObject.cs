using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class GrabObject : MonoBehaviour
{
    XRGrabInteractable grabInteractable;
    private bool grabbed;
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.selectEntered.AddListener(SetTransform);
        grabInteractable.selectExited.AddListener(RemoveTransform);
    }

    private void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(SetTransform);
        grabInteractable.selectExited.RemoveListener(RemoveTransform);
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
