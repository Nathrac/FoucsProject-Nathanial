using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeAreInTheEndgameNow : MonoBehaviour
{
    [SerializeField] List<TextMeshProUGUI> taskList = new List<TextMeshProUGUI>();
    int finalcountdown = 60;
    int timeLeft;
    [SerializeField] TextMeshProUGUI tabletClock;
    [SerializeField] TextMeshProUGUI endText;

    // Update is called once per frame
    void Update()
    {
       if (taskList.Count == 0)
        {
            endText.text = "You have finished all of the tasks, and now the application will end in" + timeLeft.ToString() + "seconds until the experience will close.";
            StartCoroutine(Timer());
        }
    }

    IEnumerator Timer() //coroutine for countdown which is displayed on the tablet tmp
    {
        int counter = finalcountdown;
        while (counter > 0)
        {
            yield return new WaitForSeconds(1);
            counter--;
            timeLeft = counter;
        }
        Application.Quit();
    }
}
