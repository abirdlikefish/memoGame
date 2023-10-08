using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
    protected IPickItem pickItem ;
    public int num;
    public bool isDestroy = true;
    protected void OnTriggerEnter2D(Collider2D other) {
        pickItem = other.GetComponent<IPickItem>();
        if(pickItem == null)
        {
            // Debug.Log("pickItem is null");
            return ;
        }
        Work();
        if(isDestroy)
        {
            Dead();
        }
        else
        {
            isDestroy = true;
        }
    }

    protected virtual void Dead()
    {
        Destroy(gameObject);
    }
    protected virtual void Work()
    {
        
    }
}
