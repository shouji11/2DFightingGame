using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderContoller : MonoBehaviour
{
    public Collider2D AttackCollider2d;
    private Animator animator;
    private DamageDealer damageDealer;
    private bool HitCancelPermit = false; //　ヒットキャンセル許可

    private bool isDamageHitStop = false; //　ダメージ受けた時のヒットストップ
    private bool isAttackHitStop = false; //　ダメージ与えた時のヒットストップ
    private bool isAttack = false;        //　アタックしたか
    
    private float attackStop, damageStop;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        damageDealer = GetComponent<DamageDealer>();
        AttackCollider2d.enabled = false;
        HitCancelPermit = false;

    }

    private void Update()
    {
        if (isDamageHitStop)
        {
            damageStop -= 0.1f;
            if (damageStop <= 0.0f)
            {
                isDamageHitStop = false;
                animator.SetFloat("DamageAnimationSpeed", 1.0f);

            }
        }

        if (isAttackHitStop)
        {
            attackStop -= 0.1f;

            if (attackStop <= 0.0f)
            {
                isAttackHitStop = false;
                animator.SetFloat("DamageAnimationSpeed", 1.0f);

            }
        }
    }


    //　Animation Eventなどから呼ぶ
    public void PunchOn()
    {
        AttackCollider2d.enabled = true;
        isAttack = true;
    }

    public void PunchOff()
    {
        AttackCollider2d.enabled = false;
        HitCancelPermit = false;
        isAttack = false;

    }

    public bool getIsAttack()
    {
        return isAttack;
    }

    /// <summary>
    /// ヒットキャンセル
    /// </summary>
    public void HitCancel()
    {
        HitCancelPermit = true;
    }
    public void HitCancelDisallowed()
    {
        HitCancelPermit = false;
    }

    /// <summary>
    /// ダメージ受けた時用ヒットストップ
    /// </summary>
    void DamageHitStop()
    {
        animator.SetFloat("DamageAnimationSpeed", 0.0f);
        isDamageHitStop = true;
        damageStop = 0.5f;
        
    }

    /// <summary>
    /// 攻撃判定が当たった時用ヒットストップ
    /// </summary>
    void AttackHitStop()
    {
        animator.SetFloat("AttackAnimationSpeed", 0.0f);
        isAttackHitStop = true;
        attackStop = 0.3f;
    }

    public void HitRigidity()
    {
       // hitRigidityTime += 0.1f;
        

    }


}
