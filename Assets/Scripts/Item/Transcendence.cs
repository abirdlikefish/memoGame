using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Transcendence  : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddTranscendence();
    }
}
