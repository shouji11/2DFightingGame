using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterControl : MonoBehaviour
{
    private bool regularDirec;       //正規向き　true = 右向き、false = 左向き
    private bool isGraund;           //着地してるか
    private float pushForce = 6.0f;  //押す力
    private bool controller = false; //コントロール

    [SerializeField] CharacterStatus characterStatus;
    [SerializeField] DamageDealer damageDealer, damageDealer2;
    [SerializeField] PushingBox pushing;
    [SerializeField] PlayerHPGaugeUI gaugeUI;
    [SerializeField] Animator animator;
    [SerializeField] Transform Opponent;    
    [SerializeField] HitGround hitGround;

    private Vector3 pushingVec;


    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        damageDealer.GetComponent<DamageDealer>();
        damageDealer2.GetComponent<DamageDealer>();
        pushing.GetComponent<PushingBox>();        
    }


    private void FixedUpdate()
    {
        isPushingGround(); //キャラクターと地面の押し合い
        isPushingPlayer(); //キャラクター同士の押し合い
        EnableGuardReactionDist(); //

        transform.position += pushingVec;
    }


    /// <summary>
    /// 地面に触れているか
    /// </summary>
    /// <returns>地面に触れて</returns>
    public bool IsGraund()
    {
        isGraund = false;

        //接触
        if (hitGround.IsGround())
        {
            isGraund = true;

            animator.SetTrigger("IsLanding");
        }

        return isGraund;
    }

    /// <summary>
    /// ダメージ制御
    /// ダメージを受けた際アニメーションなどを再生する
    /// </summary>
    public void DamageControl()
    {
        //　自分のダメージ判定が感知したら
        bool isHitAttack = false;

        if (damageDealer.IsHitDamage() ||
            damageDealer2.IsHitDamage())
        {
            animator.PlayInFixedTime("Damage", 0);

            isHitAttack = true;
        }

        animator.SetBool("Damage", isHitAttack);

    }

    /// <summary>
    /// KOダウン制御
    /// </summary>
    public void DownControl()
    {
        const short endVitality = 0;
        if (gaugeUI.GetVitalityValue() <= endVitality)
        {
            animator.SetBool("Down", true);
        }
    }

    /// <summary>
    /// キャラの向いている方向による処理
    /// </summary>
    public void PlayerFlip()
    {
        Vector3 scale1 = transform.localScale;

        //　自分の座標が相手の座標より 左側 だったら :　右向き
        if (transform.position.x <
            Opponent.transform.position.x)
        {
            scale1.x = 1;
            regularDirec = true;
        }
        else
        {
            //　自分の座標が相手の座標より 右側 だったら :　左向き
            scale1.x = -1;
            regularDirec = false;
        }

        transform.localScale = scale1;
    }

    /// <summary>
    /// キャラクターを画面内に納める
    /// </summary>
    public void PlayerInScreen()
    {
        const float screen = 0.5f; //調節用
        Vector3 screen_LeftBottom = Camera.main.ScreenToWorldPoint(Vector3.zero);
        Vector3 screen_RightTop = Camera.main.ScreenToWorldPoint(
            new Vector3(Screen.width, Screen.height, -10));

        //
        if (transform.position.x < screen_LeftBottom.x + screen)
        {
            transform.position = new Vector3(screen_LeftBottom.x + screen,
                transform.position.y, transform.position.z);
        }
        else if (transform.position.x > screen_RightTop.x - screen)
        {
            transform.position = new Vector3(screen_RightTop.x - screen,
                transform.position.y, transform.position.z);
        }
    }

    /// <summary>
    /// プレイヤーの向き
    /// </summary>
    /// <returns></returns>
    public bool PlayerDirection()
    {
        return regularDirec;
    }

    /// <summary>
    /// 地面との接触押し合い
    /// </summary>
    void isPushingGround()
    {
        if (!isGraund) return;

        pushingVec.y = 0 ;

    }

    /// <summary>
    /// プレイヤー同士の押し合い
    /// </summary>
    void isPushingPlayer()
    {
        float pushVec = 0;

        if (pushing.isPushing())
        {
            if (regularDirec)
            {
                pushVec = -1;
            }
            else
            {
                pushVec = 1;

            }
        }
     
        pushingVec.x = pushVec * pushForce * Time.deltaTime;
        
    }

    /// <summary>
    /// ガード反応距離
    /// </summary>
    public bool EnableGuardReactionDist()
    {
        const short guardEnable = -4;

        //　自分と相手の距離
        float DistanceX = transform.position.x - Opponent.transform.position.x;

        if (DistanceX < guardEnable)
        {
            return true;
        }

        return false;
    }

    /// <summary>
    /// コントロールを無効にする
    /// </summary>
    public void DisableController()
    {
        controller = false;

    }

    /// <summary>
    /// コントロールを有効にする
    /// </summary>
    public void EnableController()
    {
        controller = true;
    }

    public bool GetController()
    {
        return controller;
    }

}
