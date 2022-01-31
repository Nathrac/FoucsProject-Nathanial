using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class SwitchHands : MonoBehaviour
{
    [SerializeField] Transform leftHandAttach;
    [SerializeField] Transform rightHandAttach;
    [SerializeField] GameObject leftHandInteractor;
    [SerializeField] GameObject rightHandInteractor;
    XRGrabInteractable grabInteractable;



    // Start is called before the first frame update
    void Start()
    {
        grabInteractable = GetComponent<XRGrabInteractable>();
    }

    public void SwapHands()
    {
        if (grabInteractable.selectingInteractor.name == leftHandInteractor.name)
        {
            grabInteractable.attachTransform = leftHandAttach;
        }
        if (grabInteractable.selectingInteractor.name == rightHandInteractor.name)
        {
            grabInteractable.attachTransform = rightHandAttach;
        }
    }
}
