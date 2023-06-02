using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    SpriteRenderer _spriteRenderer;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();
    }
    
    public void RunAnim(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
        if(move < 0 )
        {
            _spriteRenderer.flipX = true;
        }
        else if (move > 0 ) 
        {
            _spriteRenderer.flipX = false;
        }
    }

    public void JumpAnim(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }
}
