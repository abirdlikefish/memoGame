using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Events;

public class Player_State : MonoBehaviour , IPickItem
{

//  UI event
    
    public UnityEvent<int> FixBombNumUI_playerState ;
    public UnityEvent<int> FixKeyNumUI_playerState ;
    public UnityEvent<int> FixMoneyNumUI_playerState ;


    // public bool isMove {get;}
    // public bool isFree {get;}
    // public bool isStiff {get;}
    // public bool isInvincible {get;}
    // public bool isDead {get;}
    // public bool isFire {get;}
    // public bool isPick {get;}
    // public bool isFullHP {get;}

    [Header("bool变量")]
    public bool isMove ;
    public bool isFree ;
    public bool isStiff ;
    public bool isInvincible ;
    public bool isDead ;
    public bool isFire ;
    public bool isPick ;
    // public bool isNearItem ;
    public bool ifFired ;
    public bool ifMoved ;
    public bool ifPicked;
    public bool ifHideBody ;

    public bool flashing ;
    public bool isFullHP {set;get;}



    [Header("CD")]
    public bool isFireCD ;
    public float fireCD_lef ;
    public bool isStiffCD ;
    public float stiffCD_lef ;
    // public bool isInvincibleCD ;
    public float invincibleCD_lef ;


    // public float speed {get;}
    // public float strength {get;}
    // public float fireRate {get;}
    // public float fireRange {get;}
    // public float bulletSpeed {get;}

    [Header("int 变量")]
    public int hardNess ;
    public int bombNum;
    public int moneyNum ;
    public int keyNum{set;get;} 

    [Header("float变量")]
    public float speed ;
    public int strength;
    public float fireRate ;
    public float fireRange ;
    public float bulletSpeed ;
    public float stiffCD ;
    public float invincibleCD ;

    

    // public Vector2 face_head {get;}
    // public Vector2 face_body {get;}
    [Header("vector2变量")]
    public Vector2 face_head ;
    public Vector2 face_body ;

    private Player player ;
    private Player_State_HP player_state_HP ;

    
    SpriteRenderer body_renderer ;
    Transform player_head ;
    SpriteRenderer head_renderer ;
    
    // Start is called before the first frame update
    void Awake()
    {
        SetInitialState();
        SetInitialEvent();
        body_renderer = GetComponent<SpriteRenderer>();
        player_head = transform.Find("Player_head");
        head_renderer = player_head.GetComponent<SpriteRenderer>();

        flashing = false ;
    }

    void SetInitialState()
    {
        isMove = false;
        isFree = true;
        isStiff = false;
        isInvincible = false;
        isDead = false;
        isFire = false;
        isPick = false;
        isFullHP = true;
        isFireCD = false;
        // isNearItem = false ;

        ifFired = false ;
        ifMoved = false ;
        ifPicked = false ;
        ifHideBody = false ;

        hardNess = 1;
        bombNum = 1;
        keyNum = 0;
        moneyNum = 0;

        speed = 6.0f;
        strength = 4;
        fireRate = 1.5f;
        fireRange = 10.0f;
        bulletSpeed = 12.0f;
        stiffCD = 1.0f ;
        invincibleCD = 1.0f ;

        player_state_HP = GetComponent<Player_State_HP>();
        player_state_HP.redHeart = player_state_HP.maxRedHeart = 6;


    }

    private void Start() {
        FixBombNumUI_playerState?.Invoke(bombNum);
        FixKeyNumUI_playerState?.Invoke(keyNum);
        FixMoneyNumUI_playerState?.Invoke(moneyNum);
    }

    void SetInitialEvent()
    {
        player = GetComponent<Player>();        

        player.Move_bef += FixBool_Move;
        player.Move_bef += FixFace_Move;

        player.Fire_bef += FixBool_Fire;
        player.Fire_bef += FixFace_Fire;
        
        player.Fire_aft += Judge_IfFired;

        player.WaitingCD += CD_Reduce ;

        player.IntoCD_fire += IntoCD_fire ;

    }

    void FixBool_Move(Vector2 vec)
    {
        if(vec.magnitude < 0.0001f )
        {
            isMove = false;
        }
        else
        {
            isMove = true;
        }
        isFree = true;
        // Debug.Log("FixBool_Move");
        // Debug.Log(vec.x.ToString() + " " + vec.y.ToString() + " " + isMove );
    }

    void FixFace_Move(Vector2 vec)
    {
        if(!isFire)
        {
            face_head = vec;
        }
        face_body = vec;
    }

    void FixFace_Fire(Vector2 vec)
    {
        if(vec.sqrMagnitude > 0.001)
        {
            face_head = vec;
        }
    }

    void FixBool_Fire(Vector2 vec)
    {
        if(vec.magnitude < 0.0001f )
        {
            isFire = false;
        }
        else
        {
            isFire = true;
        }
        isFree = true;
    }

    void CD_Reduce()
    {
        float reduced_time = Time.deltaTime;
        if( isFireCD)
        {
            fireCD_lef -=  reduced_time;
            if(fireCD_lef <= 0)
            {
                isFireCD = false;
            }
        }
        if( isStiffCD)
        {
            stiffCD_lef -=  reduced_time;
            if(stiffCD_lef <= 0)
            {
                isStiffCD = false;
            }
        }
        if( isInvincible)
        {
            flashing = !flashing ;
            head_renderer.enabled = flashing;
            if(!ifHideBody)
            {
                body_renderer.enabled = flashing;
            }

            invincibleCD_lef -=  reduced_time;
            if(invincibleCD_lef <= 0)
            {
                isInvincible = false;
                head_renderer.enabled = true ;
                
                if(!ifHideBody)
                {
                    body_renderer.enabled = true ;

                }
            }
        }
    }

    void Judge_IfFired()
    {
        if(isFire == true && isFireCD == false )
        {
            ifFired = true ;
        }
        else
        {
            ifFired = false ;
        }
    }
    void IntoCD_fire()
    {
        if(ifFired)
        {
            isFireCD = true ;
            fireCD_lef = 1 / (fireRate ) - 1.0f / 30.0f;
            ifFired = false ;
        }
    }

    public void BeInvincible()
    {
        isInvincible = true ;
        invincibleCD_lef = invincibleCD ;
    }

    public void AddHP(bool ifRedHert, int num)
    {
        player_state_HP.AddHP(ifRedHert , num);
    }

    public void AddBomb(int num)
    {
        Debug.Log("AddBomb");
        bombNum += num;
        FixBombNumUI_playerState?.Invoke(bombNum);
    }

    public void AddKey(int num)
    {
        keyNum += num;
        FixKeyNumUI_playerState?.Invoke(keyNum);
    }

    public void AddMoney(int num)
    {
        moneyNum += num;
        FixMoneyNumUI_playerState?.Invoke(moneyNum);
    }
    public void UseKey()
    {
        keyNum --;
        FixKeyNumUI_playerState?.Invoke(keyNum);
    }
    public void UseBomb()
    {
        bombNum --;
        FixBombNumUI_playerState?.Invoke(bombNum);
        // FixBombNumUI_playerState?.Invoke(0);
    }

    public void AddTheHalo()
    {
        player_state_HP.AddMaxHP();
    }

    public void AddTranscendence()
    {
        GetComponent<Collider2D>().isTrigger = true ;
        ifHideBody = true ;
        body_renderer.enabled = false ;
    }

    public void AddSpoonBender()
    {
        Player_Fire player_fire = player_head.GetComponent<Player_Fire>();
        player_fire.bullet_prefab = player_fire.bullet_spoon_prefab ;
    }
}


