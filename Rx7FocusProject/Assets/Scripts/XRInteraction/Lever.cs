using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using TMPro;

public class Lever : MonoBehaviour
{
    HingeJoint leverHinge;
    [SerializeField] TextMeshProUGUI Task;
    [SerializeField] private UnityEvent TaskRemove; //custom event
    WeAreInTheEndgameNow endGame;
    [SerializeField] int taskListNumber;
    [SerializeField] int taskNumber;
    bool leverpulled = false;
    [SerializeField] AudioSource uiSelect;
    
    

    void Awake() //get the hinge component of the lever
    {
        leverHinge = GetComponent<HingeJoint>();
        endGame = GameObject.Find("GameManager").GetComponent<WeAreInTheEndgameNow>();
    }

    public void TaskDestroy() //change task text, as setting to non active can be nulled by page changer
    {
       Task.text = "Task " + taskNumber.ToString() + " Complete";
    }

    private void Update() //check everyframe if lever has reached limit
    {
        if (leverHinge.angle == leverHinge.limits.min   && !leverpulled) //if lever reaches angle, tablet is set to active, and lever is not pulled then do the following.
        {
            uiSelect.Play(); //play select audio to indicate successful pull
            endGame.taskList[taskListNumber] = null; //set list item to null
            endGame.ListCheck(); //check if all items are null in game manager script
            TaskRemove.Invoke(); //destroy task from game
            leverpulled = true; //set lever bool to true as not to trigger update again
        }
    }
}
