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
    [SerializeField] AudioSource fobClick;
    [SerializeField] InputActionReference carStart;
    [SerializeField] InputActionReference carEnd;
    XRBaseInteractor interactor;
    [SerializeField] int idleStart; // wait time until idle starts playing on loop
    bool coruOn = false; // if engine coroutine is on


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
                fobClick.Play();
                StartCoroutine(EngineRunning()); 
            }
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right")) //if in right hand activate with right button
        {
            if (coruOn == false)
            {
                fobClick.Play();
                StartCoroutine(EngineRunning());
            }
        }
    }


    private void CarOff(InputAction.CallbackContext obj) //secondary button will turn off car
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            if (coruOn == true) //if engine on coroutine is playing, then you can turn the car off
            {
                fobClick.Play();
                startEngine.Stop();  //turn off running engine sounds before turning "engine off" audio on
                engineIdle.Stop();
                engineOff.Play();
                coruOn = false; //set engine on coroutine to false to be able to start engine again
            }
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            if (coruOn == true)
            {
                fobClick.Play();
                startEngine.Stop();
                engineIdle.Stop();
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
        coruOn = true; //set coroutine to true so it can't be turned on unless turned off first
    }
   
}
