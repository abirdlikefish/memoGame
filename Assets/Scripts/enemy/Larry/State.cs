
using UnityEngine;

public abstract class State
{
    public int ID;
    // public Rigidbody2D rigidbody2D;
    // public Animator animator;
    // public float moveSpeed;
    // public Larry LefLarry ;
    // public Larry RigLarry ;
    public Larry myLarry;
    // public Transform stateTransform;
    public virtual void OnEnter()
    {

    }
    public virtual void OnFixUpdate()
    {

    }
    public virtual void OnExit()
    {

    }
    public virtual void ChangeState()
    {

    }
    public virtual void Dead()
    {
        
    }
}