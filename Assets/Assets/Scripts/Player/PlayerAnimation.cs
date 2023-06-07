using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    Animator _animator;
    Animator _swordAnim;
    SpriteRenderer _spriteRenderer;
    SpriteRenderer _swordArcSprite;

    void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
        _spriteRenderer = GetComponentInChildren<SpriteRenderer>();

        _swordAnim = transform.GetChild(1).GetComponent<Animator>();
        _swordArcSprite = transform.GetChild(1).GetComponent<SpriteRenderer>();      
    }
    
    public void RunAnim(float move)
    {
        _animator.SetFloat("Move", Mathf.Abs(move));
        if(move < 0 )
        {
            _swordArcSprite.flipX = true;
            _swordArcSprite.flipY = true;

            Vector3 newPos = new Vector3(-0.4f, -0.09f, -0.25f);
            _swordArcSprite.gameObject.transform.localPosition = newPos;
            _swordArcSprite.gameObject.transform.localRotation = Quaternion.Euler(125.1f, 25f, -80f);

            _spriteRenderer.flipX = true;
        }
        else if (move > 0 ) 
        {
            _swordArcSprite.flipX = false;
            _swordArcSprite.flipY = false;

            Vector3 newPos = new Vector3(0.4f, -0.09f, -0.25f);
            _swordArcSprite.gameObject.transform.localPosition = newPos;
            _swordArcSprite.gameObject.transform.localRotation = Quaternion.Euler(66f, 48f, -80f);

            _spriteRenderer.flipX = false;
        }
    }

    public void JumpAnim(bool jumping)
    {
        _animator.SetBool("Jumping", jumping);
    }

    public void AttackAnim(float move)
    {
        _animator.SetTrigger("Attack");
        _swordAnim.SetTrigger("SwordAnim");
    }

    public void DeathAnim()
    {
        _animator.SetTrigger("Death");
    }
}
