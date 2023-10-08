// using System.Collections;
// using System.Collections.Generic;
// using UnityEngine;

// public class Eye : MonoBehaviour
// {
//     // Start is called before the first frame update
//     void Start()
//     {
        
//     }

//     // Update is called once per frame
//     void Update()
//     {
        
//     }
// }


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;

public class Eye : MonoBehaviour
{
    public bool ifUsed = false;
    public Transform target = null;
    private void OnTriggerEnter2D(Collider2D other) {
        // Debug.Log(0);
        if(target != null )
        {
            // Debug.Log(1);
            return ;
        }
        if(other.tag != "Enemy")
        {
            // Debug.Log(other.tag);
            // Debug.Log(other.name);
            return ;
        }
        // Debug.Log(3);
        Transform mid = other.GetComponent<Transform>() ;
        // if(mid == null)
        // {
        //     Debug.Log("666");
        // }
        target = mid ;
    }
    void Update()
    {
        if(ifUsed)
        {
            Destroy(gameObject);
        }
    }
}