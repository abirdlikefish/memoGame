using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Bullet_spoon : MonoBehaviour , ISetBullet
{
    [Header("属性")]
    public int strength ;
    public int hardness ;
    // public float speed ;
    public float fireRange_sqr ;
    public int shooterIndex ;
    float speed ;
    float flyDistance ;
    bool ifGetTarget ;
    Vector2 enemyDirection;
    Transform target;
    Rigidbody2D rb;
    public Eye eye ;

    float CD = 0.3f;
    float lastTime ;


    // Start is called before the first frame update
    void Awake()
    {
        hardness = 1 ;
        strength = 1;
        shooterIndex = 1 ;
        flyDistance = 0;
        ifGetTarget = false ;
        rb = GetComponent<Rigidbody2D>();
        eye = transform.GetChild(0).GetComponent<Eye>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (flyDistance * flyDistance > fireRange_sqr)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("isDestroyed" , true);
            Collider2D collider2D = GetComponent<Collider2D>();
            collider2D.enabled = false ;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0,0);
            Destroy(gameObject , 0.5f);
        }
        else
        {
            flyDistance += Time.deltaTime * speed;

            if(Time.time - lastTime < CD)
            {
                return;
            }
            else
            {
                lastTime = Time.time;
            }

            if(ifGetTarget&& target == null)
            {
                return ;
            }
            if(ifGetTarget&& target != null)
            {
                Debug.Log("FindTarget");
                enemyDirection = (target.transform.position - transform.position).normalized ;
                rb.velocity = speed * enemyDirection;
                return ;
            }
            if(eye.target == null)
            {
                return ;
            }

            ifGetTarget = true ;
            this.target = eye.target;
            (transform.GetChild(0).GetComponent<Eye>() as Eye ).ifUsed = true;
        }
    }

    

    // private void OnTriggerStay2D(Collider2D other) 
    private void OnTriggerEnter2D(Collider2D other)
    {
        IBeAttacked beAttacked = other.GetComponent<IBeAttacked>();
        if(beAttacked == null)
        {
            return ;
        }
        if(shooterIndex == 0 && beAttacked.myIndex == 0)
        {
            return ;
        }
        if(shooterIndex == 1 && beAttacked.myIndex == 1)
        {
            return ;
        }
        beAttacked.InvokeBeAttacked(strength , hardness , new Vector2( transform.position.x , transform.position.y) );
        // bullet.InvokeDestory();
        Animator animator = GetComponent<Animator>();
        animator.SetBool("isDestroyed" , true);
        Collider2D collider2D = GetComponent<Collider2D>();
        collider2D.enabled = false ;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = new Vector2(0,0);
        Destroy(gameObject , 0.5f);

        // Debug.Log("onTriggerEnter2D");
    }

    public void SetBullet(int strength, int hardness , int shooterIndex , Vector2 speed, float fireRange_sqr,Vector2 position)
    {
        this.strength = strength ;
        this.hardness = hardness ;
        this.shooterIndex = shooterIndex ;
        this.speed = speed.magnitude ;
        rb.velocity = speed;
        this.fireRange_sqr = fireRange_sqr ;
        transform.position = position ;


        speed = speed.normalized;
        float angle = Mathf.Atan2(speed.y, speed.x) * Mathf.Rad2Deg;
        Quaternion rotation = Quaternion.Euler(new Vector3(0, 0, angle));
        eye.transform.rotation = rotation;


    // public Vector2 targetDirection;

    // private void Start()
    // {
    //     // 计算从朝右方向到目标方向的角度

    //     // 创建一个新的旋转Quaternion

    //     // 将物体旋转到新的角度
    // }



    }
}
