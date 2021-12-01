using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class HandAnimation : MonoBehaviour
{
    //Tutorial followed to set up hand animations based on grip and trigger button distance travelled
    [SerializeField] InputActionReference controllerGrip;
    [SerializeField] InputActionReference controllerTrigger;

    Animator handAnimator;

    private void Awake()
    {
        controllerGrip.action.performed += GripPress;
        controllerTrigger.action.performed += TriggerPress;

        handAnimator = GetComponent<Animator>();
    }

    private void TriggerPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Trigger", obj.ReadValue<float>());
    }

    private void GripPress(InputAction.CallbackContext obj)
    {
        handAnimator.SetFloat("Grip", obj.ReadValue<float>());
    }
}
