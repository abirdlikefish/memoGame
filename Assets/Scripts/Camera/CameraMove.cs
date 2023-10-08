using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour
{
    // Start is called before the first frame update
    
    public bool up;
    public bool down;
    public bool lef;
    public bool rig;
    float moveTime;
    float moveTime_lef;
    bool isMove ;
    Vector3 speed ;

    private void Awake() {
        up = false ;
        down = false ;
        lef = false ;
        rig = false ;

        isMove = false ;
        speed = new Vector3(0,0,0);
        moveTime = 0.5f;
    }

    public void Move_lef()
    {
        // transform.position += new Vector3(-32 , 0 , 0);

        if(isMove)
        {
            return;
        }
        isMove = true;
        moveTime_lef = moveTime;
        speed = new Vector3(-32 / moveTime , 0, 0);
    }
    public void Move_rig()
    {
        // transform.position += new Vector3(32 , 0 , 0);

        if(isMove)
        {
            return;
        }
        isMove = true;
        moveTime_lef = moveTime;
        speed = new Vector3(32 / moveTime , 0, 0);
    }
    public void Move_up()
    {
        // transform.position += new Vector3(0 , 18 , 0);

        if(isMove)
        {
            return;
        }
        isMove = true;
        moveTime_lef = moveTime;
        speed = new Vector3(0 , 18 / moveTime, 0);
    }
    public void Move_down()
    {
        // transform.position += new Vector3(0 , -18 , 0);

        if(isMove)
        {
            return;
        }
        isMove = true;
        moveTime_lef = moveTime;
        speed = new Vector3(0 , -18 / moveTime , 0);
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if(isMove)
        {
            transform.position += speed * Time.deltaTime;
            moveTime_lef -= Time.deltaTime;
            if(moveTime_lef <= 0)
            {
                isMove = false;
            }
        }
    }
}
