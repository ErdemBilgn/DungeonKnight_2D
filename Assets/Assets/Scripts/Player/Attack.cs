using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class Attack : MonoBehaviour
{
    bool _canDamage = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!_canDamage) return;

        Debug.Log("Hit: " + other.gameObject.name);

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
        yield return new WaitForSeconds(1);
        _canDamage = true;
    }
}
