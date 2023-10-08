

public class Key : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddKey(num);
    }
}