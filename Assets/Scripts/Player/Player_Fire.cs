using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Fire : MonoBehaviour
{
    // public Transform childTransform; 
    public GameObject bullet_prefab ;
    public GameObject bullet_bomb_prefab ;
    public GameObject bullet_spoon_prefab ;
    public Player_State player_state;

    private void Awake() {
        // player_state = GetComponent<Player_State>();
    }

    // void Fire(GameObject other)
    public void Fire()
    {
        // Debug.Log(0);
        GameObject bullet = Instantiate(bullet_prefab);
        ISetBullet iBullet = bullet.GetComponent<ISetBullet>();
        Vector3 position = transform.position;
        Vector2 speed = player_state.face_head ;
        if(speed.x > 0.05 && speed.y > 0.05)
        {
            speed = new Vector2(0,1);
        }
        else if(speed.x < -0.05 && speed.y > 0.05)
        {
            speed = new Vector2(0,1);
        }
        else if(speed.x > 0.05 && speed.y < -0.05)
        {
            speed = new Vector2(0,-1);
        }
        else if(speed.x < -0.05 && speed.y < -0.05)
        {
            speed = new Vector2(0,-1);
        }
        iBullet.SetBullet(player_state.strength, 1 , 0 , (speed * player_state.bulletSpeed) , player_state.fireRange * player_state.fireRange , new Vector2(position.x,position.y) + speed );
        // iBullet.SetBullet(player_state.strength, 1 , 1 , (player_state.face_head * player_state.bulletSpeed) , player_state.fireRange * player_state.fireRange , new Vector2(position.x,position.y) );

    }

    public void SetBomb()
    {
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(bullet_bomb_prefab,myPosition , noRotation);
    }

}

