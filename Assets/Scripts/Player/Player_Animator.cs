using System.Collections;
using System.Collections.Generic;
using UnityEngine;


 
public class Player_Animator : MonoBehaviour
{
    Player player;
    Player_State player_state;
    Animator animator_head;
    Animator animator_body;
    Transform head;
    SpriteRenderer spriteRendererBody;
    // Renderer renderer;


    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        player_state = GetComponent<Player_State>();
        head = transform.GetChild(0);
        animator_head = head.GetComponent<Animator>();
        spriteRendererBody = GetComponent<SpriteRenderer>();
        // renderer = GetComponent<Renderer>();

        animator_body = GetComponent<Animator>();
        player.Move_aft += PlayAnimation_Move;
        player.Fire_aft += PlayAnimation_Fire;
        player.Dead += PlayAnimation_Dead ;
        player.BeAttacked += PlayAnimation_Attacked ;
// if(animator_body == null)
// {
//     Debug.Log("animator_body is null");
// }
    }

    void PlayAnimation_Move()
    {
        animator_body.SetBool("isMove" , player_state.isMove);
        animator_body.SetFloat("face_body_x",player_state.face_body.x);
        animator_body.SetFloat("face_body_y",player_state.face_body.y);
        // Debug.Log(player_state.isMove);
    }
    void PlayAnimation_Fire()
    {
        // animator_head.SetBool("isMove" , player_state.isMove || player_state.isFire );
        animator_head.SetBool("isFire" , player_state.isFire );
        animator_head.SetBool("isCD" , player_state.isFireCD );
        animator_head.SetFloat("face_head_x",player_state.face_head.x);
        animator_head.SetFloat("face_head_y",player_state.face_head.y);
    }

    void PlayAnimation_Dead()
    {
        // animator_body.SetBool("isDead" , true);
        animator_head.SetBool("isDead" , true);
        animator_body.enabled = false ;
    }

    void PlayAnimation_Attacked(int strength , int hardness , Vector2 position)
    {
        // animator_body.SetBool("isAttacked" , true );
        animator_head.SetBool("isAttacked" , true );
        // animator_body.enabled = false ;
        spriteRendererBody.enabled = false ;
        // renderer.enabled = false ;

    }
    // public void SetSpriteRendererBody_True()
    // {
    //     spriteRendererBody.enabled = true;
    // }
}
