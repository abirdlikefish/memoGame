using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI ;

public class ChangeHPUI : MonoBehaviour
{
    public EventSO eventSO;

    public Sprite heart_empty;
    public Sprite heart_red_1;
    public Sprite heart_red_2;
    public Sprite heart_gray_1;
    public Sprite heart_gray_2;
    public Sprite EmptyImage ;

    int pre_heart = 25;

    public void ChangeHP(int maxRedHeart , int redHeart , int grayHeart)
    {
        if( (redHeart + 1) / 2 + (grayHeart + 1) / 2 > pre_heart )
        {
            Debug.Log("unable to show HP");
            return ;
        }
        int lef = 0;
        for(int i = 0 ; i < redHeart / 2 ; i++)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = heart_red_2;
            lef++;
        }
        if(redHeart % 2 == 1)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = heart_red_1;
            lef++;
        }

        int lefEmptyHeart = (maxRedHeart / 2) - lef ;
        for(int i = 0 ; i < lefEmptyHeart ; i++)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = heart_empty;
            lef++;
        }

        for(int i = 0 ; i < grayHeart / 2 ; i++)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = heart_gray_2;
            lef++;
        }
        if(grayHeart % 2 == 1)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = heart_gray_1;
            lef++;
        }

        for(;lef < pre_heart ; lef ++)
        {
            transform.GetChild(lef).GetComponent<Image>().sprite = EmptyImage;
        }
    }

    // Start is called before the first frame update
    void Awake()
    {
        eventSO.FixHeartUI += ChangeHP;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
