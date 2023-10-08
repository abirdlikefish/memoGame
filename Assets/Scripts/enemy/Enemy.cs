using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour , IBeAttacked
{
    public GameObject player ;
    public int HP ;
    public int moveSpeed ;
    public int strength ;
    public int hardness ;
    public float visualField_sq ;
    public float stiff_CD ;
    public float stiff_CD_lef ;
    public bool isStiff ;
    public int myIndex { get; set; } = 1;
    public Room room ;


    public virtual void Start()
    {
        room = transform.parent.GetComponent<Room>();
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    public virtual void Update()
    {
        CD_Reduce();
    }
    public virtual void CD_Reduce()
    {
        if(isStiff)
        {
            stiff_CD -= Time.deltaTime;
            if(stiff_CD <= 0)
            {
                isStiff = false ;
            }
        }
    }

    public void InvokeBeAttacked(int strength, int hardness, Vector2 position)
    {
        HP -= strength ;
        isStiff = true ;
        stiff_CD_lef = stiff_CD ;
        if(HP <= 0)
        {
            Enemy_Dead();
        }
    }

    public virtual void Enemy_Dead()
    {
        Destroy(gameObject);
        room.enemyNum --;
    }

    IBeAttacked beAttacked;
    public virtual void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log("OnTriggerEnter");
        beAttacked = other.GetComponent<IBeAttacked>();
        if(beAttacked == null)
        {
            return;
        }
        if(beAttacked.myIndex != 0)
        {
            return ;
        }
        beAttacked.InvokeBeAttacked(strength , hardness , transform.position);
    }
    public bool JudgeIfInside(Vector3 position)
    {
        if(position.x < room.minX || position.x > room.maxX || position.y < room.minY || position.y > room.maxY )
        {
            return false;
        }
        else
        {
            return true;
        }

    }
}
