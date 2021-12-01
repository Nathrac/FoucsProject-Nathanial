using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyFob : MonoBehaviour
{
    //Gets audio components and interactible to play audio source when trigger is pressed. 
    XRGrabInteractable grabInteractable;
    [SerializeField] AudioSource startEngine;
    [SerializeField] AudioSource idleEngine;

    private void Awake()
    {
        //Sets up the interactible to wait for the trigger to be pressed and play audio
        grabInteractable = GetComponent<XRGrabInteractable>();
        grabInteractable.activated.AddListener(playAudio);
    }

    private void playAudio(ActivateEventArgs arg0)
    {
        //start sound coroutine when trigger is pressed.
        StartCoroutine(CarSounds());
    }

    private IEnumerator CarSounds()
    {
        //coroutine to play start sound and then loop the idle sound. 
        startEngine.Play();

        yield return new WaitForSeconds(1f);

        idleEngine.Play();
    }
}
