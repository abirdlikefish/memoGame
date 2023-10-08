

public class Heart : Item
{
    public bool isRedHeart ;
    protected override void Work()
    {
        base.Work();
        if(pickItem.isFullHP && isRedHeart)
        {
            isDestroy = false ;
            return;
        }
        pickItem.AddHP(isRedHeart , num);
    }
}