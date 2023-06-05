using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float speed;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected bool isHit = false;
    protected Player player;
    public virtual void Init()
    {
        currentTarget = pointB.position;
        animator = GetComponentInChildren<Animator>();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        player = FindObjectOfType<Player>();
    }

    void Awake()
    {
        Init();
    }

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetBool("InCombat")) // Iddle playing
        {
            return;
        }
        Movement();
    }

    public virtual void Movement()
    {


        if (currentTarget == pointA.position)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
        if (transform.position == pointA.position)
        {
            currentTarget = pointB.position;
            animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            currentTarget = pointA.position;
            animator.SetTrigger("Idle");
        }

        if(!isHit)
        {
            transform.position = Vector3.MoveTowards(transform.position, currentTarget, speed * Time.deltaTime);
        }

        float distance = Vector3.Distance(transform.localPosition, player.transform.localPosition);
        if (distance > 5)
        {
            isHit = false;
            animator.SetBool("InCombat", false);
        }

    }

}

    


