using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class ChangeKeyNumUI : MonoBehaviour
{
    public EventSO eventSO;
    public Text text ;

    private void Awake() {
        text = GetComponent<Text>();
        eventSO.FixKeyNumUI += ChangeKeyNum ;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChangeKeyNum(int num)
    {
        Debug.Log("ChangeKeyNum");
        text.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
