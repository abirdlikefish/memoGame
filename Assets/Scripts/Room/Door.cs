using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public Room room;
    public GameObject nextRoom ;
    public CameraMove mainCamera;

    public bool ifNeedKey ;

    public float moveDistance_x;
    public float moveDistance_y;

    public virtual void Awake()
    {
        room = transform.parent.GetComponent<Room>();
        if(room == null)
        {
            Debug.Log("room is null");
            return ;
        }
        mainCamera = Camera.main.GetComponent<CameraMove>();
        if(mainCamera == null)
        {
            Debug.Log("mainCamera is null");
            return ;
        }
        // Debug.Log(1);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && room.isOpen)
        {
            if(ifNeedKey)
            {
                IPickItem pickItem = other.GetComponent<IPickItem>();
                if(pickItem.keyNum <= 0)
                {
                    return ;
                }
                else
                {
                    pickItem.UseKey();
                    ifNeedKey = false ;
                }
            }
            other.transform.position = transform.parent.transform.position + new Vector3(moveDistance_x , moveDistance_y , 0);

            nextRoom.SetActive(true);
            if(moveDistance_x > 1)
            {
                mainCamera.Move_rig();
            }
            if(moveDistance_x < -1)
            {
                mainCamera.Move_lef();
            }
            if(moveDistance_y > 1)
            {
                mainCamera.Move_up();
            }
            if(moveDistance_y < -1)
            {
                mainCamera.Move_down();
            }

        }
    }
}
