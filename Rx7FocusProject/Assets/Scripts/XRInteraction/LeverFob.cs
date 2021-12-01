using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LeverFob : MonoBehaviour
{
    HingeJoint leverHinge;
    [SerializeField] GameObject fob;

    // Start is called before the first frame update
    void Start()
    {
        //Gets the information of the Hinge Joint component on the lever to set the activater in update.
        leverHinge = GetComponent<HingeJoint>();
    }

    // Update is called once per frame
    void Update()
    {
        //Once the lever is pulled to a specific angle limit the key fob will appear
        if (leverHinge.angle == leverHinge.limits.max)
        {
            fob.SetActive(true);

        }
    }
}
