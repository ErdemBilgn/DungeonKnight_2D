using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] float attackCoolDown = 0.7f;
    bool _canDamage = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_canDamage) return;

        IDamageable hit = other.GetComponent<IDamageable>();
        if(hit != null)
        {
            hit.Damage();
            StartCoroutine(DamageCooldownRoutine());
        }
    }

    IEnumerator DamageCooldownRoutine()
    {
        _canDamage = false;
        yield return new WaitForSeconds(attackCoolDown);
        _canDamage = true;
    }
}
