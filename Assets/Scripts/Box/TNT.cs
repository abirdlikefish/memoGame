using UnityEngine;


public class TNT : Box
{
    public GameObject bomb_prefab;
    override protected void Awake() {
        base.Awake();
        HP = 3 ;
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
        
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(bomb_prefab,myPosition , noRotation);
    }

}
