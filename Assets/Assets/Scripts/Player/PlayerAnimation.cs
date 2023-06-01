using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    
    public void RunAnim(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
    }
}
