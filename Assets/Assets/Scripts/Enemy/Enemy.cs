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
    [SerializeField] protected GameObject diamondPrefab;

    protected Vector3 currentTarget;
    protected Animator animator;
    protected SpriteRenderer spriteRenderer;

    protected bool isHit = false;
    protected bool isDead = false;
    protected Player player;
    protected virtual void Init()
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

    protected virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle") && !animator.GetBool("InCombat")) // Iddle playing
        {
            return;
        }
        if(!isDead)
        {
            Movement();
        }
        if(player.isDead)
        {
            animator.SetBool("InCombat", false);
            animator.SetTrigger("Idle");
        }
        
    }

    protected virtual void Movement()
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


        Vector3 direction = player.transform.localPosition - transform.position;

        if (animator.GetBool("InCombat"))
        {
            if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
            else
            {
                spriteRenderer.flipX = false;
            }
        }

    }

    protected IEnumerator SpawnGems()
    {
        float diamondForce = 7f;

        
        for (int i = 0; i < gems ; i++)
        {
            Vector3 randomOffset = Random.insideUnitSphere * diamondForce;
            if(randomOffset.y < 0)
            {
                randomOffset.y *= -1;
            }

            GameObject diamond = Instantiate(diamondPrefab, transform.position, Quaternion.identity);

            diamond.GetComponent<Rigidbody2D>().AddForce(randomOffset, ForceMode2D.Impulse);
            yield return new WaitForSeconds(0.1f);
        }
    }

    protected IEnumerator Die()
    {
        isDead = true;
        animator.SetTrigger("Death");
        StartCoroutine(SpawnGems());
        GetComponent<BoxCollider2D>().enabled = false;
        yield return new WaitForSeconds(4f);
        Destroy(this.gameObject);
    }

}

    


