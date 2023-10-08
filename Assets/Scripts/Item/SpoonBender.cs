using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpoonBender : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddSpoonBender();;
    }
}
