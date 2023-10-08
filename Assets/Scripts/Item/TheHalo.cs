using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TheHalo : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddTheHalo();
    }
}
