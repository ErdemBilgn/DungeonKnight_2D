using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    Spider spider;

    void Awake()
    {
        spider = GetComponentInParent<Spider>();
    }

    void CallAcidAttack()
    {
        spider.AcidAttack();
    }
}
