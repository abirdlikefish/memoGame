using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_SetIsAttackedFalse : MonoBehaviour
{
    Animator animator;

    void Awake()
    {
        animator = GetComponent<Animator>();
    }
    public void SetIsAttackedFalse()
    {
        animator.SetBool("isAttacked",false);
    }
}
