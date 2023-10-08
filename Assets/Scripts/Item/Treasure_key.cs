
using UnityEngine;

public class Treasure_key : Item
{
    public GameObject Heart_1_Prefab;
    public GameObject Heart_2_Prefab;
    public GameObject Key_Prefab;
    public GameObject Bomb_Prefab;
    protected override void Work()
    {
        base.Work();
        if(pickItem.keyNum <= 0)
        {
            isDestroy = false;
            return ;
        }
        pickItem.UseKey();
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(Heart_1_Prefab,myPosition + new Vector3(0.5f, 1.0f, 0) , noRotation);
        Instantiate(Heart_2_Prefab,myPosition + new Vector3(-0.5f, 1.0f, 0) , noRotation);
        Instantiate(Key_Prefab,myPosition + new Vector3(-1.5f, 1.0f, 0) , noRotation);
        Instantiate(Bomb_Prefab,myPosition + new Vector3(1.5f, 1.0f, 0) , noRotation);
    }
}