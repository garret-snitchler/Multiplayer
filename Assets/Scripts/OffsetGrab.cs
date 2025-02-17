using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactors;
using UnityEngine.XR.Interaction.Toolkit.Interactables;
using System;


public class MyXRInteractor : MonoBehaviour
{
    public XRBaseInteractor interactor; // Reference to the XRInteractor


    private void OnEnable()
    {
        // Make sure we subscribe to the events when the interactor is enabled
        if (interactor)
        {
            interactor.selectEntered.AddListener(OnSelectEnter);
            interactor.selectExited.AddListener(OnSelectExit);
        }
    }

    private void OnDisable()
    {
        // Unsubscribe from events when the interactor is disabled
        if (interactor)
        {
            interactor.selectEntered.RemoveListener(OnSelectEnter);
            interactor.selectExited.RemoveListener(OnSelectExit);
        }
    }

    private void OnSelectEnter(SelectEnterEventArgs args)
    {
        //// Handle the select entered event
        //Debug.Log("Object selected: " + args.interactableObject.gameObject.name);
    }

    private void OnSelectExit(SelectExitEventArgs args)
    {
        //// Handle the select exited event
        //Debug.Log("Object deselected: " + args.interactableObject.gameObject.name);
    }
}
