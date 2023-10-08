using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Bullet : MonoBehaviour , ISetBullet
{
    [Header("属性")]
    public int strength ;
    public int hardness ;
    // public float speed ;
    public float fireRange_sqr ;
    public int shooterIndex ;
    public Vector2 beginPosition ;


    // Start is called before the first frame update
    void Awake()
    {
        hardness = 1 ;
        strength = 1;
        shooterIndex = 1 ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if ((new Vector2(transform.position.x, transform.position.y) - beginPosition).sqrMagnitude > fireRange_sqr)
        {
            Animator animator = GetComponent<Animator>();
            animator.SetBool("isDestroyed" , true);
            Collider2D collider2D = GetComponent<Collider2D>();
            collider2D.enabled = false ;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.velocity = new Vector2(0,0);
            Destroy(gameObject , 0.5f);
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
        // this.speed = speed ;
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        rb.velocity = speed;
        this.fireRange_sqr = fireRange_sqr ;
        // this.shooterIndex = shooterIndex ;
        this.beginPosition = position;
        transform.position = position ;
    }
}
