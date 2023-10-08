
using UnityEngine;

public class Coin : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddMoney(num);
    }
}