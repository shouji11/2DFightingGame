using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackDealer : MonoBehaviour
{
    public bool HitDamage = false; //　攻撃判定確認用
    const string DamageTag = "Damage";

    bool IsHitAttack()
    {        
        return HitDamage;
    }

    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if(collider2D.CompareTag(DamageTag))
        {
            HitDamage = true;
        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.CompareTag(DamageTag))
        {
            HitDamage = false;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {

        if (collider2D.CompareTag(DamageTag))
        {
            HitDamage = false;
        }
    }

}
