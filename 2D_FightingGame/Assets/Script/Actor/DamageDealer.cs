using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum damageTipe
{
    Normal,         //　通常
    Throw,          //　投げ

}

public class DamageDealer : MonoBehaviour
{
    private damageTipe damageTipe;
    public bool HitAttack = false; //　攻撃判定確認

    private const string AttackTag = "Attack";
    private bool hitStopFlag = false; //ヒットストップフラグ
    private float hitStopCount; //ヒットストップカウント




    /// <summary>
    /// ヒット通知
    /// </summary>
    /// <returns></returns>
    public bool IsHitDamage()
    {        
        return HitAttack;
    }

    public bool getHitStop()
    {
        return hitStopFlag;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        //　相手のAttackとついたタグと当たったら
        if (collider2D.CompareTag(AttackTag))
        {

            HitAttack = true;
            hitStopFlag = true;
        }

    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        HitAttack = false;
        hitStopFlag = false;

    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        HitAttack = false;
        hitStopFlag = false;

    }

}
