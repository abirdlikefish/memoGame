using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System ;

public class Spike : MonoBehaviour 
{
    private void OnTriggerEnter2D(Collider2D other) {
        IBeAttacked beAttacked = other.GetComponent<IBeAttacked>();
        if(beAttacked == null)
        {
            return ;
        }
        if(beAttacked.myIndex == 2)
        {
            return ;
        }
        beAttacked.InvokeBeAttacked(1 , 1 , new Vector2( transform.position.x , transform.position.y) );
    }
}