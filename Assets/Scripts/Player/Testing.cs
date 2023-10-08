using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Testing : MonoBehaviour
{
    // Start is called before the first frame update
    Player_State player_State;
    void Start()
    {
        player_State = GetComponent<Player_State>();
        
    }
    bool ifPressed = false;
    // Update is called once per frame
    void Update()
    {
        if(Keyboard.current.tabKey.wasPressedThisFrame)
        {
            if(ifPressed)
            {
                player_State.strength = 4;
                player_State.speed = 6;
                ifPressed = false;

            }
            else
            {
                player_State.strength = 100;
                player_State.speed = 10;
                ifPressed = true;
            }
        }
    }
}
