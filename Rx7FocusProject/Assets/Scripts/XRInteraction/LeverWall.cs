using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverWall : MonoBehaviour
{
    HingeJoint leverHinge;
    [SerializeField] GameObject wall;
    [SerializeField] GameObject car;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the information of the Hinge Joint component on the lever to set the activater in update.
        leverHinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    { 
        //Once the lever is pulled to a specific angle limit, the wall will disappear and the car will appear
        if (leverHinge.angle == leverHinge.limits.min)
        {
            wall.SetActive(false);
            car.SetActive(true);

        }
    }
}
