using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;


public class OffsetGrab : UnityEngine.XR.Interaction.Toolkit.Interactables.XRGrabInteractable
{
    private Vector3 interactorPosition = Vector3.zero;
   // private Vector3 interactorPositionX = Vector3.up(0,0,-3);
    private Quaternion interactorRotation = Quaternion.identity;

    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);
        StoreInteractor(args.interactorObject);
        MatchAttachmentPoints(args.interactorObject);

    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        ResetAttachmentPoints(args.interactorObject);
        ClearInteractor(args.interactorObject);
    }

    private void StoreInteractor(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor)
    {
        interactorPosition = interactor.transform.localPosition;
        interactorRotation = interactor.transform.localRotation;
    }

    private void MatchAttachmentPoints(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor)
    {
        bool hasAttach = attachTransform != null;
        interactor.transform.position = hasAttach ? attachTransform.position : interactor.transform.position;
        interactor.transform.rotation = hasAttach ? attachTransform.rotation : interactor.transform.rotation;
    }

    private void ResetAttachmentPoints(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor)
    {
        interactor.transform.localPosition = interactorPosition;
        interactor.transform.localRotation = interactorRotation;
    }

    private void ClearInteractor(UnityEngine.XR.Interaction.Toolkit.Interactors.IXRSelectInteractor interactor)
    {
        interactorPosition = Vector3.zero;
        interactorRotation = Quaternion.identity;
    }
}
