using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class ChangeMoneyNumUI : MonoBehaviour
{
    public EventSO eventSO;
    public Text text ;

    private void Awake() {
        text = GetComponent<Text>();
        eventSO.FixMoneyNumUI += ChangeMoneyNum ;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChangeMoneyNum(int num)
    {
        Debug.Log("ChangeMoneyNum");
        text.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
