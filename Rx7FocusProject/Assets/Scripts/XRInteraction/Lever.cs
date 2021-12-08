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
    [SerializeField] int tasknum;
    bool leverpulled = false;
    [SerializeField] AudioSource uiSelect;
    

    void Awake() //get the hinge component of the lever
    {
        leverHinge = GetComponent<HingeJoint>();
        endGame = GameObject.Find("GameManager").GetComponent<WeAreInTheEndgameNow>();
    }

    public void TaskDestroy() //destroy task, as setting to non active can be nulled by page changer
    {
        Destroy(Task);
    }

    private void Update() //check everyframe if lever has reached limit
    {
        if (leverHinge.angle == leverHinge.limits.max && !leverpulled) //if lever reaches angle, tablet is set to active, and lever is not pulled then do the following.
        {
            uiSelect.Play();
            endGame.taskList[tasknum] = null; //set list item to null
            endGame.ListCheck(); //check if all items are null in game manager script
            TaskRemove.Invoke(); //destroy task from game
            leverpulled = true; //set lever bool to true as not to trigger update again
        }
    }
}
