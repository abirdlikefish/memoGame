
using UnityEngine;

public class Bag : Item
{
    public GameObject coin_1_prefab;
    public GameObject coin_2_prefab;
    protected override void Work()
    {
        base.Work();
        Vector3 myPosition = transform.position;
        Quaternion noRotation = Quaternion.identity;
        Instantiate(coin_1_prefab,myPosition + new Vector3(0.5f, 0.5f, 0) , noRotation);
        Instantiate(coin_2_prefab,myPosition + new Vector3(-0.5f, 0.5f, 0) , noRotation);
    }
}