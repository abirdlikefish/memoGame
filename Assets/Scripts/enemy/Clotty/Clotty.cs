// using System.Numerics;
using UnityEngine;

public class Clotty : Enemy
{
    public GameObject bullet_tearBlood_prefab;
    float move_CD ;
    float move_CD_lef ;
    float bulletSpeed ;
    float bulletRange_sq ; 
    bool isMoveCD;
    bool isMove ;
    public Vector3 targetDirection;
    // Collider2D collider2D ;
    Rigidbody2D rigidbody2D;
    Animator animator;
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

        // collider2D = GetComponent<Collider2D>();
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
                    //攻击动画
                    targetDirection = playerPosition - transform.position;
                    rigidbody2D.velocity = targetDirection * 0.7f;
                }
                else
                {
                    targetDirection = GetRandomDirection();
                    rigidbody2D.velocity = targetDirection.normalized * moveSpeed;
                }
                isMove = true;
                animator.SetBool("isMove", true);
            }
        }
    }

    public void Arrive()
    {
        isMove = false;
        isMoveCD = true ;
        move_CD_lef = move_CD ;
        // collider2D.enabled = true;
        rigidbody2D.velocity = new Vector2(0,0);
        animator.SetBool("isMove", false);


        GameObject bullet1 = Instantiate(bullet_tearBlood_prefab);
        GameObject bullet2 = Instantiate(bullet_tearBlood_prefab);
        GameObject bullet3 = Instantiate(bullet_tearBlood_prefab);
        GameObject bullet4 = Instantiate(bullet_tearBlood_prefab);
        ISetBullet iBullet1 = bullet1.GetComponent<ISetBullet>();
        ISetBullet iBullet2 = bullet2.GetComponent<ISetBullet>();
        ISetBullet iBullet3 = bullet3.GetComponent<ISetBullet>();
        ISetBullet iBullet4 = bullet4.GetComponent<ISetBullet>();
        iBullet1.SetBullet(strength, hardness , 1 , new Vector2(0,1) * bulletSpeed , bulletRange_sq , transform.position );
        iBullet2.SetBullet(strength, hardness , 1 , new Vector2(0,-1) * bulletSpeed , bulletRange_sq , transform.position );
        iBullet3.SetBullet(strength, hardness , 1 , new Vector2(-1,0) * bulletSpeed , bulletRange_sq , transform.position );
        iBullet4.SetBullet(strength, hardness , 1 , new Vector2(1,0) * bulletSpeed , bulletRange_sq , transform.position );


    }

    private System.Random random = new System.Random();
    public Vector3 GetRandomDirection()
    {
        Vector3 returnDirection = new Vector3(0,0,0);
        bool ifCorrect = false ;
        int testTime = 0;
        do
        {
            testTime ++;
            if(testTime > 1000)
            {
                Debug.Log("Unable to get random direction");
                Destroy(gameObject);
            }
            float randomAngle = (float)random.NextDouble() * 360f;
            // 将角度转换为弧度
            float angleInRadians = randomAngle * Mathf.Deg2Rad;

            // 使用三角函数计算随机点的坐标
            // float x = transform.position.x + moveSpeed * Mathf.Cos(angleInRadians);
            // float y = transform.position.y + moveSpeed * Mathf.Sin(angleInRadians);
            // returnDirection = new Vector3(x,y,0);
            returnDirection = new Vector3(Mathf.Cos(angleInRadians),Mathf.Sin(angleInRadians),0);

            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, returnDirection, moveSpeed + 1);
            if(hit)
            {
                // Debug.Log("Physics.Raycast");
                // Debug.Log(hit.collider.name);
                
                continue;
            }
            else
            {
                ifCorrect = true;
                break;
            }

        }
        while(!ifCorrect);

        return returnDirection;
    }

}