using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Control : MonoBehaviour
{
    private Player player ;
    private Player_State player_state;
    Transform player_head;
    private Player_Fire player_fire;
    private NewControls inputSystem;

    // Start is called before the first frame update
    void Awake()
    {
        player = GetComponent<Player>();
        player_state = GetComponent<Player_State>();
        inputSystem = new NewControls();
        inputSystem.Enable();
        // inputSystem = GetComponent<NewControls>();
        player_head = transform.Find("Player_head");
        player_fire = player_head.GetComponent<Player_Fire>();
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        player.InvokeWaitingCD();
        
        if(player_state.isStiff == false && player_state.isFree && player_state.isDead == false) 
        {
        
            player.InvokeMove_bef(inputSystem.Player.Move.ReadValue<Vector2>());
            player.InvokeFire_bef(inputSystem.Player.Fire.ReadValue<Vector2>());

            player.InvokeMove_aft();
            player.InvokeFire_aft();

            player.InvokeIntoCD_fire();

        }
    }


    public void OnSetBomb(InputAction.CallbackContext context)
    {
        if(player_state.isStiff || !player_state.isFree) 
        {
            return;
        }
        // if(context.started)
        // {
        //     Debug.Log("ahahah");
        // }
        if(context.started && player_state.bombNum > 0)
        {
            player_fire.SetBomb();
            player_state.UseBomb();
        }
    }

}
