using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{
    public int Health { get; set; }

    [SerializeField] GameObject acidPrefab;

    public override void Init()
    {
        base.Init();
        Health = base.maxHealth;
    }

    public override void Update()
    {

    }

    public void Damage()
    {
        Health--;
        if(Health < 1)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
    }

    public override void Movement()
    {
        //Sit still.
    }

    public void AcidAttack()
    {
        Instantiate(acidPrefab, transform.position, Quaternion.identity);
    }
}
