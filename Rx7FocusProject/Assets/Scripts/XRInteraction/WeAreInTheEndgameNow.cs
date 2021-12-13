using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeAreInTheEndgameNow : MonoBehaviour
{
    public List<TextMeshProUGUI> taskList = new List<TextMeshProUGUI>();
    int finalcountdown = 60;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] TextMeshProUGUI deathTimer;
    [SerializeField] GameObject end;
    [SerializeField] GameObject buttons;
    [SerializeField] GameObject instuctions;
    bool taskComplete = false;


    IEnumerator DeathTimer() //coroutine for countdown which is displayed on the tablet tmp. Once it reaches 0, application will close down
    {
        int timeleft = finalcountdown;
        while (timeleft > 0)
        {
            yield return new WaitForSeconds(1);
            timeleft--;
            deathTimer.text = timeleft.ToString();
        }

        Application.Quit();
    }

    public void ListCheck() //check if all list items are null, if not then tasks are not complete, if so, start death timer
    {
        for (int i = 0; i < taskList.Count; i++)
        {
            if (taskList[i] != null)
            {
                taskComplete = false;
                break;
            }
            else
            {
                taskComplete = true;
            }

        }

        if (taskComplete)
        {
            instuctions.SetActive(false);
            end.SetActive(true);
            buttons.SetActive(false);
            StartCoroutine(DeathTimer());
        }
    }
}
