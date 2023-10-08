using UnityEngine ;
using System.Collections.Generic;
using Unity.VisualScripting;

public class State_head : State
{
    public float changeDirectionTime ;
    public float lastChangeDirectionTime ;
    override public void OnEnter()
    {
        ID = 0;
        changeDirectionTime = Random.Range(0.5f,2.0f);
        lastChangeDirectionTime = Time.time;
        myLarry.animator.SetInteger("ID" , ID);
    }
    public override void OnExit()
    {
        base.OnExit();
        // myLarry.animator.SetInteger("ID" , ID);
    }

    public override void OnFixUpdate()
    {
        base.OnFixUpdate();
        if(Time.time - lastChangeDirectionTime > changeDirectionTime)
        {
            Vector2 vector2 = GetRandomDirection();
            if(myLarry.rigLarry != null && (myLarry.rigLarry.GetComponent("Larry") as Larry).nowState != null)
            {
                ((myLarry.rigLarry.GetComponent("Larry") as Larry).nowState as State_body).WillChangeDirection(vector2 , Time.time);
            }
            myLarry.rigidbody2D.velocity = vector2 * myLarry.moveSpeed ;
            myLarry.animator.SetFloat("direction_x",vector2.x);
            myLarry.animator.SetFloat("direction_y",vector2.y);
            lastChangeDirectionTime = Time.time;
            changeDirectionTime = Random.Range(0.5f,2.0f);
            return ;
        }

        RaycastHit2D hit;
        hit = Physics2D.Raycast(myLarry.transform.position, myLarry.rigidbody2D.velocity , 0.5f);
        if(hit)
        {
            Vector2 vector2 = GetRandomDirection();
            if(myLarry.rigLarry != null && (myLarry.rigLarry.GetComponent("Larry")as Larry).nowState != null)
            {
                ((myLarry.rigLarry.GetComponent("Larry") as Larry).nowState as State_body).WillChangeDirection(vector2 , Time.time);
            }
            myLarry.rigidbody2D.velocity = vector2 * myLarry.moveSpeed ;
            myLarry.animator.SetFloat("direction_x",vector2.x);
            myLarry.animator.SetFloat("direction_y",vector2.y);
            lastChangeDirectionTime = Time.time;
            changeDirectionTime = Random.Range(0.3f,2.0f);

        }

    }

    public override void Dead()
    {
        base.Dead();
    }

    public Vector2 GetRandomDirection()
    {
        int whileTime = 0;
        while(true)
        {
            whileTime ++;
            if(whileTime >= 100)
            {
                Debug.Log("failed to get random direction");
                return new Vector2(0,0);
            }

            int x = Random.Range(0,4);
            Vector2 vector2 = new Vector2(0,0);
            if(x == 0)
            {
                vector2 = new Vector2(0,1);
            }
            if(x == 1)
            {
                vector2 = new Vector2(0,-1);
            }
            if(x == 2)
            {
                vector2 = new Vector2(1,0);
            }
            if(x == 3)
            {
                vector2 = new Vector2(-1,0);
            }
            RaycastHit2D hit;
            hit = Physics2D.Raycast(myLarry.transform.position, vector2 , 3);
            if(!hit)
            {
                return vector2;
            }
        }
    }
}