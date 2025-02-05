using System;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using UnityEngine.XR.Interaction.Toolkit.Interactors;

public class GrabObject : MonoBehaviour
{
    XRGrabInteractable grab;
    private bool grabbed;
    void OnEnable()
    {
        grab = GetComponent<XRGrabInteractable>();
        grab.selectEntered.AddListener(SetTransform);
        grab.selectExited.AddListener(RemoveTransform);
    }

    private void OnDisable()
    {
        grab.selectEntered.RemoveListener(SetTransform);
        grab.selectExited.RemoveListener(RemoveTransform);
    }

    void SetTransform(SelectEnterEventArgs args)
    {
        Transform obj = args.interactableObject.transform;

        obj.TryGetComponent(out SnapObject found);
        
        if (found)
        {
            if (SnapManager.Instance().targetSnapObject == null)
            {
                SnapManager.Instance().targetSnapObject = found;
            }
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
