using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_rig : Door
{
    public override void Awake()
    {
        base.Awake();
        moveDistance_x = 22;
        moveDistance_y = 0;
    }
}
