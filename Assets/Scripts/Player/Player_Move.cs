using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Player player;
    Player_State player_state;
    Rigidbody2D rb;

    Camera mainCamera ;
    
    void Awake()
    {
        mainCamera = Camera.main;
    }

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Player>();
        player_state = GetComponent<Player_State>();
        rb = GetComponent<Rigidbody2D>();

        player.Move_bef += FixSpeed_Move;
    }

    // Update is called once per frame
    void Update()
    {
    }

    void FixedUpdate()
    {
    }

    void FixSpeed_Move(Vector2 vec)
    {
        float maxX = mainCamera.transform.position.x + 15;
        float minX = mainCamera.transform.position.x - 15;
        float maxY = mainCamera.transform.position.y + 8;
        float minY = mainCamera.transform.position.y - 8;
        // Debug.Log(maxX.ToString() + " " + minX.ToString() + " " +  maxY.ToString() + " " + minY.ToString());
        if(transform.position.x + vec.x > maxX || transform.position.x + vec.x < minX || transform.position.y + vec.y > maxY || transform.position.y + vec.y < minY)
        {
            rb.velocity = new Vector2(0,0);
            return ;
        }
        else
        {
            rb.velocity = player_state.speed * vec ;
        }
    }

}
