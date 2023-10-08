using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Unity.VisualScripting;

public static class Formula
{
    static public float FireRate(float fireRate)
    {
        if(fireRate >= 425.0f/234.0f)
        {
            return 5.0f / 30.0f ;
        }
        else if(fireRate >= 0)
        {
            return (float)(( 16.0f - 6.0f * Math.Sqrt(1.3f * fireRate + 1) ) / 30.0f);
        }
        else if(fireRate >= -10.0f / 13.0f)
        {
            return (float)(( 16.0f - 6.0f * Math.Sqrt(1.3f * fireRate + 1) - 6.0f ) / 30.0f);
        }
        else 
        {
            return (float)(16.0f - 6.0f * fireRate);
        }
    }

    static public bool Possible(float probability)
    {
        if(probability < 0)
        {
            return false;
        }
        if(probability > 1)
        {
            return true ;
        }
        float judge = UnityEngine.Random.Range(0,1.0f);
        Debug.Log(judge < probability);
        return judge < probability ;
    }
}
