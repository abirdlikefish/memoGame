using UnityEngine;


public class Fire : Box
{
    override protected void Awake() 
    {
        base.Awake();
        HP = 4 ;
        hardness = 1 ;
        animator.SetInteger("HP",HP);
    }
    public override void InvokeBeAttacked(int strength, int hardness, Vector2 position)
    {
        base.InvokeBeAttacked(strength, hardness, position);
        
        if(this.hardness == hardness)
        {
            transform.localScale = new Vector3(0.7f * transform.localScale.x , 0.7f * transform.localScale.y , 0)  ;
        }
        else if(this.hardness < hardness)
        {
        }
    }

    protected override void Dead()
    {
        base.Dead();
        animator.enabled = false;
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.enabled = false ;

        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other) {
        IBeAttacked beAttacked = other.GetComponent<IBeAttacked>();
        if(beAttacked == null)
        {
            return ;
        }
        if(beAttacked.myIndex == 2)
        {
            return ;
        }
        beAttacked.InvokeBeAttacked(1 , 1 , new Vector2( transform.position.x , transform.position.y) );
    }

}
