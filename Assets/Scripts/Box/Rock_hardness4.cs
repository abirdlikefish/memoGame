using UnityEngine;


public class Rock_Hardness4 : Box
{
    override protected void Awake() {
        HP = 1 ;
        hardness = 4 ;
        collider2D = GetComponent<Collider2D>();
    }
    public override void InvokeBeAttacked(int strength, int hardness, Vector2 position)
    {
        if(this.hardness <= hardness)
        {
            Dead();
        }

    }

    protected override void Dead()
    {
        
        base.Dead();
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false ;
    }

}
