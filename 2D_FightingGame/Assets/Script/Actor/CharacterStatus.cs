using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStatus : MonoBehaviour
{
    public int Vitality;    //体力
    public int attackPoint;//攻撃力
    public float moveSpeed;//機動力
    public float jumpPower; //ジャンプ力

    //専用アニメーション
    public AnimatorOverrideController animatiorOverride;
    private Animator animator;
    private AudioClip[] audioClip;

    /// <summary>
    /// 体力取得
    /// </summary>
    /// <returns></returns>
    public int GetVitality()
    {
        return Vitality;
    }

    /// <summary>
    /// 攻撃力取得
    /// </summary>
    /// <returns></returns>
    public int GetAttackPoint()
    {
        return attackPoint;
    }

    /// <summary>
    /// ジャンプ力取得
    /// </summary>
    /// <returns></returns>
    public float GetJumpPower()
    {
        return jumpPower;
    }

    /// <summary>
    /// 移動スピード取得
    /// </summary>
    /// <returns></returns>
    public float GetMoveSpeed()
    {
        return moveSpeed;
    }

    public Animator GetAnimator()
    {
        
        return animator;
    }



}
