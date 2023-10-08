using UnityEngine ;
using System.Collections.Generic;

public class State_body : State
{

    float changeDirectionTime ;
    Queue<float> beginTime =  new Queue<float>();
    Queue<Vector2> changeDirection = new Queue<Vector2>(); 
    public bool ifGenerateShit = false;

    float lastShitTime ;
    float shitTime;
    public override void OnEnter()
    {
        base.OnEnter();
        ID = Random.Range(1,4);
        changeDirectionTime = 2.0f / myLarry.moveSpeed;
        // beginTime.Clear();
        // changeDirection.Clear();
        myLarry.animator.SetInteger("ID" , ID);
        lastShitTime = Time.time;
        shitTime = Random.Range(10.0f , 15.0f);
    }
    public override void OnExit()
    {
        base.OnExit();
        // myLarry.animator.SetInteger("ID" , ID);
    }
    public override void OnFixUpdate()
    {
        base.OnFixUpdate();
        if(myLarry.lefLarry == null)
        {
            ChangeState();
            return ;
        }
        if(myLarry.rigLarry == null)
        {
            ID = 4;
            myLarry.animator.SetInteger("ID" , ID);
        }
        pullShit() ;

        if(beginTime.Count > 0)
        {
            if(Time.time - beginTime.Peek() >= changeDirectionTime )
            {
                myLarry.rigidbody2D.velocity = changeDirection.Peek() * myLarry.moveSpeed;
                if(myLarry.rigLarry != null && (myLarry.rigLarry.GetComponent("Larry") as Larry).nowState != null)
                {
                    ((myLarry.rigLarry.GetComponent("Larry") as Larry).nowState as State_body).WillChangeDirection(changeDirection.Peek() , Time.time);
                }

                beginTime.Dequeue();
                changeDirection.Dequeue();
            }
        }
        else
        {
            return;
        }
    }

    public override void ChangeState()
    {
        base.ChangeState();
        
        OnExit();
        myLarry.nowState = myLarry.headState;
        myLarry.nowState.OnEnter();
    }
    
    public override void Dead()
    {
        base.Dead();
    }

    public void pullShit()
    {
        if(ID == 4 && Time.time - lastShitTime > shitTime)
        {
            lastShitTime = Time.time;
            shitTime = Random.Range(10.0f , 15.0f);
            ifGenerateShit = true;
        }
    }

    public void WillChangeDirection(Vector2 vector2 , float changeTime)
    {
        beginTime.Enqueue(changeTime);
        changeDirection.Enqueue(vector2);
    }

}
