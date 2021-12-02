using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class KeyFob : MonoBehaviour
{
    //Gets audio components and interactible to play audio source when trigger is pressed. 
    XRGrabInteractable grabInteractable;
    [SerializeField] AudioSource startEngine;
    [SerializeField] AudioSource engineIdle;
    [SerializeField] AudioSource engineOff;
    [SerializeField] InputActionReference carStart;
    [SerializeField] InputActionReference carEnd;
    XRBaseInteractor interactor;
    [SerializeField] int idleStart;
    bool coruOn = false;
    [SerializeField] float audioFade;


    private void Awake()
    {
        //Sets up the interactible to wait for the trigger to be pressed and play audio
        grabInteractable = GetComponent<XRGrabInteractable>();
        carStart.action.started += CarOn;
        carEnd.action.started += CarOff;
    }

    public void GetInteractor()
    {
        interactor = grabInteractable.selectingInteractor;
    }

    public void ReleaseInteractor()
    {
        interactor = null;
    }

    private void CarOn(InputAction.CallbackContext obj)
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            if (coruOn == false)
            {
                StartCoroutine(EngineRunning());
                coruOn = true;
            }
        }
        else if (obj.control.ToString().Contains("Right") && interactor.name.Contains("Right"))
        {
            if (coruOn == false)
            {
                StartCoroutine(EngineRunning());
                coruOn = true;
            }
        }
    }
    private void CarOff(InputAction.CallbackContext obj)
    {
        if (obj.control.ToString().Contains("Left") && interactor.name.Contains("Left"))
        {
            if (coruOn == true)
            {
                StartCoroutine(AudioFadeCR());
                engineOff.Play();
                coruOn = false;
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

    private IEnumerator EngineRunning()
    {
        startEngine.Play();
        yield return new WaitForSeconds(idleStart);
        engineIdle.Play();
    }
   
    private IEnumerator AudioFadeCR()
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
