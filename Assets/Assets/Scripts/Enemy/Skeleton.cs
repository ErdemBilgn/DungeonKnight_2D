using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    protected override void Init()
    {
        base.Init();
        Health = base.maxHealth;
    }

    protected override void Movement()
    {
        base.Movement();
    }

    public void Damage()
    {
        animator.SetTrigger("Hit");
        Health--;

        isHit = true;

        animator.SetBool("InCombat", true);

        if(Health < 1)
        {
            StartCoroutine(Die());
        }
    }
}
