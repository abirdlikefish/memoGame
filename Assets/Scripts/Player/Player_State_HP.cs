using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class Player_State_HP : MonoBehaviour
{
    public UnityEvent<int , int , int> FixHeartUI_playerStateHP ;
    
    [Header("int")]
    public int maxRedHeart ;
    public int redHeart;
    public int grayHeart;

    public bool isFullHP;

    Player player ;
    Player_State player_state ;



    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>() ;
        player_state = GetComponent<Player_State>();
        player.Dead += FixBool_isDead ;
        FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AddHP(bool isRedHeart , int num)
    {
        if(isRedHeart)
        {
            redHeart += num;
            if(redHeart >= maxRedHeart)
            {
                player_state.isFullHP = true ;
                redHeart = maxRedHeart;
            }
        }
        else
        {
            grayHeart += num;
        }
        FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );
    }
    public void AddMaxHP()
    {
        maxRedHeart += 2;
        redHeart += 2;
        FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );
    }

    public void DropHP(int enemyStrength)
    {
        if(grayHeart + redHeart <= enemyStrength)
        {
            redHeart = grayHeart = 0;
            player_state.isFullHP = false;
            
            FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );
            
            Dead();
            return ;
        }
        if(grayHeart > enemyStrength)
        {
            grayHeart -= enemyStrength;
        
            FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );

            return ;
        }
        else
        {
            player_state.isFullHP = false;
            redHeart -= (enemyStrength - grayHeart);
            grayHeart = 0;
            
            FixHeartUI_playerStateHP?.Invoke(maxRedHeart , redHeart , grayHeart );
    
            return ;
        }
    }

    public void Dead()
    {
        player.InvokeDead();
        player.InvokeDeathRattle();
    }
    void FixBool_isDead()
    {
        player_state.isDead = true ;

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,0);
        // Destroy(rb);
        GetComponent<Collider2D>().enabled = false;
        // Collider2D
        
        SceneManager.LoadScene("Death");

    }
}
