using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class ChangeBombNumUI : MonoBehaviour
{
    public EventSO eventSO;
    public Text text ;

    private void Awake() {
        text = GetComponent<Text>();
        eventSO.FixBombNumUI += ChangeBombNum ;
    }

    // Start is called before the first frame update
    void Start()
    {
    }

    public void ChangeBombNum(int num)
    {
        // Debug.Log("ChangeBombNum");
        text.text = num.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
