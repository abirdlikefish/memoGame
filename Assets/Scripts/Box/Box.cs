using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ;

public class Box : MonoBehaviour , IBeAttacked
{
    protected int HP ;
    protected int hardness ;
    public GameObject coin_prefab;

    protected Animator animator ;
    protected Collider2D collider2D ;
    protected virtual void Awake()
    {
        animator = GetComponent<Animator>();
        collider2D = GetComponent<Collider2D>();
    }
    protected virtual void Dead()
    {
        collider2D.enabled = false ;
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        if(Formula.Possible(0.5f))
        {
            Instantiate(coin_prefab,myPosition , noRotation);
        }
    }

    public virtual void InvokeBeAttacked(int strength, int hardness, Vector2 position)
    {
        if(this.hardness == hardness)
        {
            HP --;
            if(HP == 0)
            {
                Dead();
            }
        }
        else if(this.hardness < hardness)
        {
            HP = 0;
            Dead();
        }
        animator.SetInteger("HP", HP);

    }
    public int myIndex { get; set; } = 2;
}
