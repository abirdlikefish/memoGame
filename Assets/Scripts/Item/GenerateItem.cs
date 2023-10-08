using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateItem : MonoBehaviour
{
    public GameObject[] items = new GameObject[13];
    // Start is called before the first frame update
    void Start()
    {
        // Debug.Log(0);
        Instantiate(items[Random.Range(0,13)], transform.position , Quaternion.identity);
        // Debug.Log(1);
        Destroy(gameObject);
        // Debug.Log(2);
    }

}
