using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AwakeOfMenu: MonoBehaviour 
{
    public AchievenmentListIngame caller;
    // Start is called before the first frame update
    void Start()
    {
        caller.OpenWindow();
    }
}
