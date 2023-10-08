using System.Collections;
using System.Collections.Generic;
using UnityEngine;
 
public class Player_BeAttacked : MonoBehaviour
{

    Player player ; 
    Player_State player_state ;
    Player_State_HP player_state_HP ;
    void Start() {
        player = GetComponent<Player>();
        player_state = GetComponent<Player_State>();
        player_state_HP = GetComponent<Player_State_HP>();

        player.BeAttacked += DropHP ;
        player.BeAttacked += Repel ;
        player.BeAttacked += BeInvincible ;
    }

    // void DropHP(int enemyStrength)
    void DropHP(int strength , int hardness , Vector2 position)
    {
        player_state_HP.DropHP(strength);
    }

//击退
    void Repel(int strength , int hardness , Vector2 position)
    {

    }
    void BeInvincible(int strength , int hardness , Vector2 position)
    {
        player_state.BeInvincible();
    }
}