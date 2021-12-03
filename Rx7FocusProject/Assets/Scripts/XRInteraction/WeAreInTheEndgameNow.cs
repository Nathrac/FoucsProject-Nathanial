using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WeAreInTheEndgameNow : MonoBehaviour
{
    public List<TextMeshProUGUI> taskList = new List<TextMeshProUGUI>();
    int finalcountdown = 60;
    int timeLeft;
    [SerializeField] TextMeshProUGUI endText;
    [SerializeField] GameObject end;
    [SerializeField] GameObject buttons;

    // Update is called once per frame
    void Update()
    {
       if (taskList.Count == 0)
        {
            end.SetActive(true);
            endText.text = "You have finished all of the tasks\nand now the application will end in\n" + timeLeft.ToString() +"seconds";
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
        Debug.Log("tada");
        Application.Quit();
    }
}
