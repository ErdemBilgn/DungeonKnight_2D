using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable
{
    public int Health { get; set; }

    public override void Init()
    {
        base.Init();
        Health = base.maxHealth;
    }

    public void Damage()
    {
        animator.SetTrigger("Hit");
        Health--;

        if(Health < 1)
        {
            Debug.Log("Die");
        }
    }
}
