// using System.Numerics;
using UnityEngine;

public class RoundWorm : Enemy
{
    public GameObject bullet_tearBlood_prefab;
    float move_CD ;
    float move_CD_lef ;
    bool isMoveCD;
    bool isMove ;
    bool isIn;
    bool isOut;
    float move_time ;
    float move_time_lef ;
    float attack_CD;
    float attack_CD_lef ;
    bool isAttackCD;
    float bulletSpeed ;
    float bulletRange_sq ;
    Vector3 targetPosition;
    Collider2D collider2D ;
    // Rigidbody2D rigidbody2D;
    Animator animator;
    SpriteRenderer spriteRenderer ;
    public override void Start()
    {
        base.Start();
        HP = 15;
        moveSpeed = 8;
        strength = 1;
        hardness = 1;
        visualField_sq = 64;
        stiff_CD = 0.2f;
        stiff_CD_lef = 0;
        isStiff = false;
        move_CD = 3 ;
        move_CD_lef = 0;
        bulletSpeed = 7;
        bulletRange_sq = 64 ;
        isMoveCD = false;
        isMove = false;
        isIn = false ;
        isOut = false ;
        isAttackCD = false ;
        move_time = 2;
        move_time_lef = 0;
        attack_CD = 3;
        attack_CD_lef = 0;

        collider2D = GetComponent<Collider2D>();
        // rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }


    public override void Update()
    {
        base.Update();
        if(isAttackCD)
        {
            attack_CD_lef -= Time.deltaTime ;
            if(attack_CD_lef <= 0)
            {
                isAttackCD = false;
            }
        }

        if(isMove)
        {
            move_time_lef -= Time.deltaTime ;
            if(move_time_lef <= 0)
            {
                animator.SetBool("isOut" , true);
                spriteRenderer.enabled = true ;
                collider2D.enabled = true;
            }
        }
        else
        {
            if(isMoveCD)
            {
                move_CD_lef -= Time.deltaTime;
                if(move_CD_lef <= 0)
                {
                    isMoveCD = false ;
                }
                if( (!isAttackCD) && (player.transform.position - transform.position).sqrMagnitude < visualField_sq )
                {
                    GameObject bullet1 = Instantiate(bullet_tearBlood_prefab);
                    ISetBullet iBullet1 = bullet1.GetComponent<ISetBullet>();
                    Vector2 playerDirection = (player.transform.position - transform.position);
                    playerDirection.Normalize();
                    iBullet1.SetBullet(strength, hardness , 1 , playerDirection * bulletSpeed , bulletRange_sq , transform.position );

                    isAttackCD = true ;
                    attack_CD_lef = attack_CD;
                }
                return;
            }
            else
            {
                targetPosition = GetRandomPosition();
                isMove = true;
                move_time_lef = move_time;
                isIn = true ;
                animator.SetBool("isIn", true);
                // Debug.Log("setbool");
            }
        }
    }

    public void InGround()
    {
        
        spriteRenderer.enabled = false ;
        collider2D.enabled = false;
        transform.position = targetPosition ;
        isIn = false ;
        animator.SetBool("isIn", false);
        move_time_lef = move_time;


        // isMove = false;
        // isMoveCD = true ;
        // move_CD_lef = move_CD ;
        // collider2D.enabled = true;
        // rigidbody2D.velocity = new Vector2(0,0);
        // animator.SetBool("isMove", false);

    }

    public void OutGround()
    {
        animator.SetBool("isOut", false);
        animator.SetBool("isIn", false);
        isMove = false ;
        isMoveCD = true ;
        move_CD_lef = move_CD;
        // Debug.Log("setisMove");
    }

    private System.Random random = new System.Random();
    public Vector3 GetRandomPosition()
    {
        Vector3 returnPosition = new Vector3(0,0,0);
        bool ifCorrect = false ;
        int testTime = 0;
        do
        {
            if(testTime > 1000)
            {
                Debug.Log("Unable to get random position");
                Enemy_Dead();
            }
            float randomAngle = (float)random.NextDouble() * 360f;
            // 将角度转换为弧度
            float angleInRadians = randomAngle * Mathf.Deg2Rad;

            // 使用三角函数计算随机点的坐标
            float x = transform.position.x + moveSpeed * Mathf.Cos(angleInRadians);
            float y = transform.position.y + moveSpeed * Mathf.Sin(angleInRadians);
            returnPosition = new Vector3(x,y,0);

            Collider2D[] colliders = Physics2D.OverlapBoxAll(returnPosition, new Vector2(2,2) , 0); // 使用OverlapSphere方法进行碰撞检测
            if( colliders.Length == 0 && JudgeIfInside(returnPosition)) // 如果返回的碰撞器数组长度大于0，表示有物品与指定位置相交
            {
                ifCorrect = true;
            }
        }
        while(!ifCorrect);

        return returnPosition;
    }

}