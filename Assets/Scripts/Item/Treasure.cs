
using UnityEngine;

public class Treasure : Item
{
    public GameObject Heart_Prefab;
    public GameObject Key_Prefab;
    public GameObject Bomb_Prefab;
    protected override void Work()
    {
        base.Work();
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(Heart_Prefab,myPosition + new Vector3(1f, 1.0f, 0) , noRotation);
        Instantiate(Key_Prefab,myPosition + new Vector3(-1f, 1.0f, 0) , noRotation);
        Instantiate(Bomb_Prefab,myPosition + new Vector3(0, 1.0f, 0) , noRotation);
    }
}