using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door_up : Door
{
    public override void Awake()
    {
        base.Awake();
        moveDistance_x = 0;
        moveDistance_y = 14;
    }
}
