using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour , IBeAttacked 
{

    // 事件
    public event Action< Vector2 > Move_bef ;
    public event Action Move_aft ;
    public event Action< Vector2 > Fire_bef ;
    public event Action Fire_aft ;
    public event Action WaitingCD ;
    public event Action IntoCD_fire ;
    public event Action<int , int , Vector2 > BeAttacked ;
    public event Action Dead ;
    public event Action DeathRattle ;

//触发事件
    public void InvokeMove_bef(Vector2 vec)
    {
        Move_bef?.Invoke(vec);
    }
    public void InvokeMove_aft()
    {
        Move_aft?.Invoke();
    }
    public void InvokeFire_bef(Vector2 vec)
    {
        Fire_bef?.Invoke(vec);
    }
    public void InvokeFire_aft()
    {
        Fire_aft?.Invoke();
    }
    public void InvokeWaitingCD()
    {
        WaitingCD?.Invoke();
    }
    public void InvokeIntoCD_fire()
    {
        IntoCD_fire?.Invoke();
    }
    public void InvokeDead()
    {
        Dead?.Invoke();
    }
    public void InvokeDeathRattle()
    {
        DeathRattle?.Invoke();
    }

    //interface
    public void InvokeBeAttacked(int strength , int hardness , Vector2 position)
    {
        Player_State player_state = GetComponent<Player_State>();
        if(player_state.isInvincible == false)
        {
            BeAttacked?.Invoke(strength , hardness , position);
        }
    }
    public int myIndex { get ; set; } = 0;

}
