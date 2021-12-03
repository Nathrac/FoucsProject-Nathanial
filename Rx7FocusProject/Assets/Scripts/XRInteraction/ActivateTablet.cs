using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateTablet : MonoBehaviour
{
    public static bool tabletIsActive = false;

    public void SetTabletActive()
    {
        tabletIsActive = true;
    }
}
