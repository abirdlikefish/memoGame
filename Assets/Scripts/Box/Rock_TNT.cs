using UnityEngine;


public class Rock_TNT : Box
{
    public GameObject bomb_prefab;
    override protected void Awake() {
        HP = 1 ;
        hardness = 2 ;
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
        
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(bomb_prefab,myPosition , noRotation);
    }

}
