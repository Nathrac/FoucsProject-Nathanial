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
    

    // Start is called before the first frame update
    void Awake() //get the hinge component of the lever
    {
        leverHinge = GetComponent<HingeJoint>();
        endGame = GetComponent<WeAreInTheEndgameNow>();
    }

    public void TaskDestroy() //destroy task, as setting to non active can be nulled by page changer
    {
        Destroy(Task);
    }
   
    //public void TaskDelete() //if lever reaches a point, start custom event
    //{
    //    if (leverHinge.angle == leverHinge.limits.min && tabletActive)
    //    {
    //        TaskRemove.Invoke();
    //    }
    //}

    private void Update() //check everyframe if lever has reached limit
    {
        if (leverHinge.angle == leverHinge.limits.min && ActivateTablet.tabletIsActive)
        {
            endGame.taskList.RemoveAt(tasknum);

            TaskRemove.Invoke(); 
        }
    }
}
