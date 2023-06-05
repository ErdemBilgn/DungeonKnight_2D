using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.maxHealth;
    }

    public override void Movement()
    {
        base.Movement();

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

    public void Damage()
    {
        animator.SetTrigger("Hit");
        Health--;

        isHit = true;

        animator.SetBool("InCombat", true);

        if (Health < 1)
        {
            Debug.Log("Die");
        }
    }
}
