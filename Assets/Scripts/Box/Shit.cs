using UnityEngine;


public class Shit : Box
{
    override protected void Awake() {
        base.Awake();
        HP = 4 ;
        hardness = 1 ;
        animator.SetInteger("HP",HP);
    }
    public override void InvokeBeAttacked(int strength, int hardness, Vector2 position)
    {
        base.InvokeBeAttacked(strength, hardness, position);

    }

    protected override void Dead()
    {
        base.Dead();
    }

}
