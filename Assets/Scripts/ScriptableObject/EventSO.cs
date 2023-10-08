using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[CreateAssetMenu(fileName = "Event/EventSO")]
public class EventSO : ScriptableObject
{
    public UnityAction<int> FixBombNumUI ;
    public UnityAction<int> FixKeyNumUI ;
    public UnityAction<int> FixMoneyNumUI ;
    public UnityAction<int , int , int> FixHeartUI ;

    public void InvokeFixBombNumUI(int x)
    {
        FixBombNumUI?.Invoke(x);
    }
    public void InvokeFixKeyNumUI(int x)
    {
        FixKeyNumUI?.Invoke(x);
    }
    public void InvokeFixMoneyNumUI(int x)
    {
        FixMoneyNumUI?.Invoke(x);
    }
    public void InvokeFixHeartUI(int maxRedHeart , int redHeart , int grayHeart)
    {
        FixHeartUI?.Invoke(maxRedHeart , redHeart , grayHeart);
    }
}
