using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyFob : MonoBehaviour
{
    //Gets audio components and interactible to play audio source when primary and secondary button is pressed. 
    XRGrabInteractable grabInteractable;
    [SerializeField] AudioSource startEngine; //custom start engine audio
    [SerializeField] AudioSource engineIdle; //engine idle audio that will loop and mix with engine start
    [SerializeField] AudioSource engineOff; //custom audio for when car is turned off
    [SerializeField] InputActionReference carStart;
    [SerializeField] InputActionReference carEnd;
    XRBaseInteractor interactor;
    [SerializeField] int idleStart; // wait time until idle starts playing on loop
    bool coruOn = false; // if engine coroutine is on
    [SerializeField] float audioFade;


    private void Awake()
    {
        //Sets up the interactible to wait for the trigger to be pressed and play audio
        grabInteractable = GetComponent<XRGrabInteractable>();
        carStart.action.started += CarOn; //primary button will start car
        carEnd.action.started += CarOff; //secondary button will shutdown car
    }

    public void GetInteractor()
    {
        interactor = grabInteractable.selectingInteractor;
    }

    public void ReleaseInteractor()
    {
        interactor = null;
    }

    private void CarOn(InputAction.CallbackContext obj) //set up for primary button to be used to start the car
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left")) //if in the left hand then activate with left button
        {
            if (coruOn == false) //if coroutine is false start engine start coroutine
            {
                StartCoroutine(EngineRunning()); 
                coruOn = true; //set coroutine to true so it can't be turned on unless turned off first
            }
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right")) //if in right hand activate with right button
        {
            if (coruOn == false)
            {
                StartCoroutine(EngineRunning());
                coruOn = true;
            }
        }
    }
    private void CarOff(InputAction.CallbackContext obj) //secondary button will turn off car
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            if (coruOn == true) //if engine on coroutine is playing, then you can turn the car off
            {
                StartCoroutine(AudioFadeCR()); //fade out engine sounds before turning engine off audio
                engineOff.Play();
                coruOn = false; //set engine on coroutine to false to be able to start engine again
            }
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            if (coruOn == true)
            {
                StartCoroutine(AudioFadeCR());
                engineOff.Play();
                coruOn = false;
            }
        }
    }

    private IEnumerator EngineRunning() //coroutine to time when a looping engine idle begins to play after car start sfx plays
    {
        startEngine.Play();
        yield return new WaitForSeconds(idleStart);
        engineIdle.Play();
    }
   
    private IEnumerator AudioFadeCR() //audio fade script to fade audio without using snapshots
    {
        float t = audioFade;
        while (t > 0)
        {
            yield return null;
            t -= Time.deltaTime;
            engineIdle.volume = t / audioFade;
        }
        yield break;
    }
}
