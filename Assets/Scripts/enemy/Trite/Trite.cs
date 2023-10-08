// using System.Numerics;
using UnityEngine;

public class Trite : Enemy
{
    float move_CD ;
    float move_CD_lef ;
    bool isMoveCD;
    bool isMove ;
    Vector3 targetPosition;
    Collider2D collider2D ;
    Rigidbody2D rigidbody2D;
    Animator animator;
    public override void Start()
    {
        base.Start();
        HP = 10;
        moveSpeed = 6;
        strength = 1;
        hardness = 1;
        visualField_sq = 144;
        stiff_CD = 0.2f;
        stiff_CD_lef = 0;
        isStiff = false;
        move_CD = 3 ;
        move_CD_lef = 0;
        isMoveCD = false;
        isMove = false;

        collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public override void Update()
    {
        base.Update();
        if(isMove)
        {

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
                return;
            }
            else
            {
                Vector3 playerPosition = player.transform.position;
                if((playerPosition - transform.position).sqrMagnitude < visualField_sq)
                {
                    Debug.Log((playerPosition - transform.position).sqrMagnitude);
                    if((playerPosition - transform.position).sqrMagnitude < moveSpeed * moveSpeed)
                    {
                        targetPosition = playerPosition + new Vector3(Random.Range(-1.0f,1.0f) , Random.Range(-1.0f,1.0f) , 0);
                    }
                    else
                    {
                        targetPosition = transform.position + (playerPosition - transform.position).normalized * moveSpeed;
                    }
                }
                else
                {
                    targetPosition = GetRandomPosition();
                }
                isMove = true;
                collider2D.enabled = false;
                rigidbody2D.velocity = targetPosition - transform.position;
                animator.SetBool("isMove", true);
            }
        }
    }

    public void Arrive()
    {
        isMove = false;
        isMoveCD = true ;
        move_CD_lef = move_CD ;
        collider2D.enabled = true;
        rigidbody2D.velocity = new Vector2(0,0);
        animator.SetBool("isMove", false);

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