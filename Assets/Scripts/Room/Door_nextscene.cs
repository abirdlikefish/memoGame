using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door_nextscene : MonoBehaviour
{
    Room room;
    public String targetScene;

    public virtual void Awake()
    {
        room = transform.parent.GetComponent<Room>();
        if(room == null)
        {
            Debug.Log("room is null");
            return ;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.tag == "Player" && room.isOpen)
        {
            other.transform.position = new Vector3(0,0,0);
            Camera.main.transform.position = new Vector3(0,0,Camera.main.transform.position.z);
            SceneManager.LoadScene(targetScene);
        }
    }
}
