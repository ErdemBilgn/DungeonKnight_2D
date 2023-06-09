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
    public int _diamonds;
    public bool isDead = false;

    PlayerAnimation _playerAnim;
    void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _playerAnim = GetComponentInChildren<PlayerAnimation>();
        Health = 4;
    }


    void Update()
    {
        if (isDead) return;
        Movement();
        Attack();
    }

    void Movement()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        if(horizontal == 0)
        {
            _rb.velocity = new Vector2(0, _rb.velocity.y);
        }
        if(CheckGrounded() && Input.GetKeyDown(KeyCode.Space))
        {
            _rb.velocity = new Vector2(_rb.velocity.x, _jumpForce);            
            StartCoroutine(ResetJumpRoutine());
            _playerAnim.JumpAnim(true);
        }

        transform.Translate(Vector3.right * horizontal * _runSpeed * Time.deltaTime);
        //_rb.velocity = new Vector2(horizontal * _runSpeed * Time.deltaTime, _rb.velocity.y);
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
        if (Health <= 0)
        {
            return;
        }
        Debug.Log("Player damaged");
        Health--;
        UIManager.Instance.UpdateLives(Health);
        if(Health <= 0)
        {
            StartCoroutine(Death());
        }
    }

    public void AddGems()
    {
        _diamonds++;
        UIManager.Instance.UpdateGemCount(_diamonds);
    }

    IEnumerator Death()
    {
        _playerAnim.DeathAnim();
        isDead = true;
        yield return new WaitForSeconds(3f);
        GameManager.Instance.ReturnToMainMenu();
    }

}
