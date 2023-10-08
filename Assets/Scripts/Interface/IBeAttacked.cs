
using UnityEngine ;
interface IBeAttacked
{
    // void InvokeBeAttack(UnityEngine.Object EnemyState);
    // void InvokeBeAttacked(int strength , int hardness , float position_x , float position_y);
    void InvokeBeAttacked(int strength , int hardness , Vector2 position);
    int myIndex{set;get;}
    // 0 player
    // 1 enemy
    // 2 box
    // 3 item
    // 4 neither
}


