using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_Boom : MonoBehaviour , ISetBullet
{
    
    [Header("属性")]
    public int strength ;
    public int hardness ;
    public int shooterIndex ;

    void Awake()
    {
        hardness = 2 ;
        strength = 1;
        shooterIndex = 4 ;
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
        // Animator animator = GetComponent<Animator>();
        // animator.SetBool("isDestroyed" , true);
        // Collider2D collider2D = GetComponent<Collider2D>();
        // collider2D.enabled = false ;
        // Rigidbody2D rb = GetComponent<Rigidbody2D>();
        // rb.velocity = new Vector2(0,0);
        // Destroy(gameObject , 0.5f);

        // Debug.Log("onTriggerEnter2D");
    }

    
    public void SetBullet(int strength, int hardness , int shooterIndex , Vector2 speed, float fireRange_sqr,Vector2 position)
    {
        this.strength = strength ;
        this.hardness = hardness ;
        this.shooterIndex = shooterIndex ;
        transform.position = position ;
    }

    public void DestroyBullet_Boom()
    {
        Destroy(gameObject);
    }

}
