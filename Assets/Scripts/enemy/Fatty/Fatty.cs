// using System.Numerics;
using UnityEngine;

public class Fatty : Enemy
{
    public GameObject bullet_fatty_prefab;
    float attack_CD ;
    float attack_CD_lef ;
    float bulletSpeed ;
    float bulletRange_sq ; 
    float changeDirectionTime ;
    float changeDirectionTime_left ;
    bool isAttackCD;
    bool isAttack ;
    public Vector3 targetDirection;
    // Collider2D collider2D ;
    Rigidbody2D rigidbody2D;
    Animator animator;
    public override void Start()
    {
        base.Start();
        HP = 20;
        moveSpeed = 4;
        strength = 1;
        hardness = 1;
        visualField_sq = 144;
        stiff_CD = 0.2f;
        stiff_CD_lef = 0;
        isStiff = false;
        attack_CD = 8 ;
        attack_CD_lef = 0;
        bulletSpeed = 7;
        bulletRange_sq = 64 ;
        isAttackCD = false;
        isAttack = false;
        changeDirectionTime = 3;
        changeDirectionTime_left = 0;

        // collider2D = GetComponent<Collider2D>();
        rigidbody2D = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }


    public override void Update()
    {
        base.Update();
        if(isAttack)
        {
            return ;
        }
        if(isAttackCD)
        {
            attack_CD_lef -= Time.deltaTime ;
            if(attack_CD_lef <= 0)
            {
                isAttackCD = false ;
            }
        }
        bool ifFindPlayer = (player.transform.position - transform.position).sqrMagnitude < visualField_sq;
        if((!isAttackCD) && (player.transform.position - transform.position).sqrMagnitude < (visualField_sq / 4.0f))
        {
            isAttackCD = true;
            isAttack = true;
            attack_CD_lef = attack_CD;
            rigidbody2D.velocity = new Vector2(0,0);
            animator.SetBool("isAttack",true);
            changeDirectionTime_left = 0;
            return ;
        }
        
        if(ifFindPlayer)
        {
            targetDirection = player.transform.position - transform.position;
            changeDirectionTime_left = 0;
        }
        else if(changeDirectionTime_left <= 0.0001f)
        {
            targetDirection = GetRandomDirection();
            changeDirectionTime_left = changeDirectionTime;
        }
        else
        {
            changeDirectionTime_left -= Time.deltaTime ;
        }
        targetDirection.Normalize();
        animator.SetFloat("walkDirection_x" , targetDirection.x);
        animator.SetFloat("walkDirection_y" , targetDirection.y);
        rigidbody2D.velocity = targetDirection * moveSpeed;


    }

    public void Attack()
    {
        GameObject bullet = Instantiate(bullet_fatty_prefab , transform.position , Quaternion.identity);
        Bullet_Boom bullet_Boom = bullet.GetComponent<Bullet_Boom>();
        bullet_Boom.shooterIndex = 1;
    }

    public void EndAttack()
    {
        isAttack = false ;
        animator.SetBool("isAttack",false);

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
                Enemy_Dead();
            }
            float randomAngle = (float)random.NextDouble() * 360f;
            // 将角度转换为弧度
            float angleInRadians = randomAngle * Mathf.Deg2Rad;

            // 使用三角函数计算随机点的坐标
            returnDirection = new Vector3(Mathf.Cos(angleInRadians),Mathf.Sin(angleInRadians),0);

            RaycastHit2D hit;
            hit = Physics2D.Raycast(transform.position, returnDirection, moveSpeed * 3 + 1);
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