using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D _rb;
    [SerializeField] float _runSpeed = 5f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] LayerMask _groundLayer;
    bool _resetJump = false;

    PlayerAnimation _playerAnim;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponentInChildren<PlayerAnimation>();  
    }


    void Update()
    {
        Movement(); 
    }

    void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");

        if(Input.GetKeyDown(KeyCode.Space) && CheckGrounded())
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);
            StartCoroutine(ResetJumpRoutine());
        }

        _rb.velocity = new Vector2(horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);
        _playerAnim.RunAnim(horizontal);
    }

    bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 0.6f, _groundLayer);
        if(hitInfo.collider != null)
        {
            if(!_resetJump)
            {
                return true;
            }           
        }

        return false;
    }

    IEnumerator ResetJumpRoutine()
    {
        _resetJump = true;
        yield return new WaitForSeconds(0.1f);
        _resetJump = false;
    }
}
