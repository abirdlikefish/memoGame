using System.Collections;
using System.Collections.Generic;
using UnityEngine;

 
public class Player_DeathRattle : MonoBehaviour
{
    Player player ; 
    Player_State player_state ;
    Player_State_HP player_state_HP ;
    void Start() {
        player = GetComponent<Player>();
        player_state = GetComponent<Player_State>();
        player_state_HP = GetComponent<Player_State_HP>();
    }
}