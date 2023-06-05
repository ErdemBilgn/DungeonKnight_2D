using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{
    Rigidbody2D _rb;
    [SerializeField] float _runSpeed = 5f;
    [SerializeField] float _jumpForce = 5f;
    [SerializeField] LayerMask _groundLayer;
    bool _resetJump = false;
    float horizontal;

    public int Health { get; set;}



    PlayerAnimation _playerAnim;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponentInChildren<PlayerAnimation>();  
    }


    void Update()
    {
        Movement();
        Attack();
    }

    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);            
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.JumpAnim(true);
        }

        _rb.velocity = new Vector2(horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);
        _playerAnim.RunAnim(horizontal);
    }

    bool CheckGrounded()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, Vector2.down, 1, _groundLayer);
        Debug.DrawRay(transform.position, Vector2.down, Color.green);
        if(hitInfo.collider != null)
        {
            if(!_resetJump)
            {
                _playerAnim.JumpAnim(false);
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

    void Attack()
    {
        if(Input.GetMouseButtonDown(0) && CheckGrounded()) 
        {
            _playerAnim.AttackAnim(horizontal);
        }
    }

    public void Damage()
    {
        Debug.Log("Player damaged");
    }
}
