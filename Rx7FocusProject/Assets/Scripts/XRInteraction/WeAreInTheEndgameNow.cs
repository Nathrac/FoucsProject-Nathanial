using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeAreInTheEndgameNow : MonoBehaviour
{
    public List<TextMeshProUGUI> taskList = new List<TextMeshProUGUI>(); //list to track progress
    int finalcountdown = 30; //final countdown starts at 60 seconds

    //objects to set active and deactiviate 
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] TextMeshProUGUI deathTimer;
    [SerializeField] GameObject end;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject instuctions;
    [SerializeField] GameObject tasks;
    bool taskComplete = false;


    IEnumerator DeathTimer() //coroutine for countdown which is displayed on the tablet tmp. Once it reaches 0, application will close down
    {
        int timeleft = finalcountdown;
        while (timeleft > 0) //until the timer reaches 0, reduce time by one every second then display time to string
        {
            yield return new WaitForSeconds(1); 
            timeleft--;
            deathTimer.text = timeleft.ToString();
        }

        Application.Quit(); //once 0, force close the application
    }

    public void ListCheck() //check if all list items are null, if not then tasks are not complete, if so, start death timer
    {
        for (int i = 0; i < taskList.Count; i++) //check list if items are null, if not keep bool to false
        {
            if (taskList[i] != null)
            {
                taskComplete = false;
                break;
            }
            else
            {
                taskComplete = true; //if all are null, switch bool to true
            }

        }

        if (taskComplete) // if bool is true, turn off instructions, tasks and buttons and display end text and timer
        {
            tasks.SetActive(false);
            instuctions.SetActive(false);
            buttons.SetActive(false);
            end.SetActive(true);
            StartCoroutine(DeathTimer());
        }
    }
}
