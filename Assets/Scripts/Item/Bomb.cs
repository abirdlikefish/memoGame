

public class Bomb : Item
{
    protected override void Work()
    {
        base.Work();
        pickItem.AddBomb(num);
    }
}