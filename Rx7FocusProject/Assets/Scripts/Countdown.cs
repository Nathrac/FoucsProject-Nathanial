using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Countdown : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI clock;
    int seconds = 60;
    IEnumerator Timer() //coroutine for countdown which is displayed on the podiums tmp
    {
        int counter = seconds;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            clock.text = counter.ToString();
        }
    }
    public void BeginTimer()//method to start coroutine through button click event
    {
        StartCoroutine("Timer");  
    }
}
