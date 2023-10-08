using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_bomb : MonoBehaviour 
{
    public GameObject boom_prefab;
    float time = 2;
    bool flashing = false;
    SpriteRenderer spriteRenderer;

    void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        flashing = !flashing;
        spriteRenderer.enabled = flashing;

        time -= Time.deltaTime;
        if(time < 0)
        {
            Boom();
        }
    }

    void Boom()
    {
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(boom_prefab,myPosition , noRotation);
        Destroy(gameObject);
    }
}