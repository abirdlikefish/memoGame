// using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Larry : Enemy
{ 
    // float changeDirectionTime ;
    // Queue<float> beginTime;
    // Queue<Vector2> changeDirection ; 
    public Rigidbody2D rigidbody2D;
    public Vector3 targetDirection;
    public Animator animator;
    public State nowState;
    public State bodyState;
    public State headState;
    public GameObject lefLarry = null;
    public GameObject rigLarry = null;
    public GameObject shit ;
    public override void Start()
    {
        base.Start();
        HP = 20;
        moveSpeed = 7;
        strength = 1;
        hardness = 1;

        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        bodyState = new State_body();
        headState = new State_head();

        bodyState.myLarry = headState.myLarry = this;

        nowState = bodyState;
        nowState.OnEnter();
        rigidbody2D.velocity = new Vector2(-moveSpeed , 0);
    }


    public void FixedUpdate()
    {
        nowState.OnFixUpdate();
        if(nowState.ID == 4 && (nowState as State_body).ifGenerateShit)
        {
            Instantiate(shit, transform.position , Quaternion.identity);
            (nowState as State_body).ifGenerateShit = false;
        }
    }

    public override void Enemy_Dead()
    {
        nowState.Dead();
        base.Enemy_Dead();
    }

}