using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Room : MonoBehaviour
{
    public GameObject victory ;
    public int enemyNum = 0 ;
    public bool isOpen ;
    public bool ifHaveEnemy ;

    public float maxX;
    public float maxY;
    public float minX;
    public float minY;

    // Start is called before the first frame update
    void Awake()
    {
        isOpen = false ;
        maxX = transform.position.x + 12 ;
        minX = transform.position.x - 12 ;
        maxY = transform.position.y + 6 ;
        minY = transform.position.y - 6 ;
    }

    // Update is called once per frame
    void Update()
    {

        if((!isOpen)&&enemyNum <= 0)
        {
            isOpen = true ;
            if(ifHaveEnemy)
            {       
                Instantiate(victory, transform.position , Quaternion.identity);
            }
        }
    }
}
