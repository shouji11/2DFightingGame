using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController2 : MonoBehaviour
{
    private bool isGraund;        //着地してるか
    private bool regularDirec;      //正規向き　true = 右向き、false = 左向き
    private bool isRecession = false;               //後退
    private bool isAdvance = false;                 //前進
    private bool isCrouch = false;                  //しゃがみ
    private bool controller = false; //　コントロール
    private bool koDown = false;
    bool EnableGuard = false;
    bool isAttack = false;
    bool isJump = false;          //ジャンプしてるか

    public Animator animator;      //アニメーション
    private Rigidbody2D rb2d;
    private CharacterStatus charStatus;
    private CharacterControl characterControl;
    ColliderContoller P1_control;

    const string ObjName = "Player2";

    public Command2 inputAxes;
    private Vector3 moveVel;
    private Vector2 jumpForceVec; //ジャンプ
    
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        charStatus = GameObject.Find(ObjName).GetComponent<CharacterStatus>();
        characterControl = GameObject.Find(ObjName).GetComponent<CharacterControl>();
        P1_control = GameObject.Find("Player").GetComponent<ColliderContoller>();

    }

    // Update is called once per frame
    void Update()
    {
        controller = characterControl.GetController();
        isGraund = characterControl.IsGraund();

        if (!controller) return; //コントロール出来ないときは下の処理をしない

        regularDirec = characterControl.PlayerDirection();

        if (isGraund)
        {
            characterControl.PlayerFlip();

            //guardController();

            JumpControl();

            CrouchControl();

        }

        AttackControl();
        characterControl.DamageControl();
        characterControl.DownControl();

    }

    private void FixedUpdate()
    {
        if (!controller) return;

        if (isGraund)
        {
            MovementControl();

        }

        transform.position += moveVel;
        characterControl.PlayerInScreen();

    }



    /// <summary>
    /// 攻撃制御
    /// </summary>
    void AttackControl()
    {

        //　弱攻撃
        if (Input.GetButtonDown("Attack_A_2"))
        {
            animator.SetTrigger("Attack_A");
        }

        //　中攻撃
        if (Input.GetButtonDown("Attack_B_2"))
        {
            animator.SetTrigger("Attack_B");
        }

        //　強攻撃
        if (Input.GetButtonDown("Attack_C_2"))
        {
            animator.SetTrigger("Attack_C");
        }

    }
    
    /// <summary>
    /// ジャンプ制御
    /// </summary>
    void JumpControl()
    {
        if (inputAxes.getAxes() == 7 ||
            inputAxes.getAxes() == 8 ||
            inputAxes.getAxes() == 9)
        {
            //　垂直ジャンプ
            if (inputAxes.getAxes() == 8)
            {
                jumpForceVec = new Vector2(0, 1);
            }

            //　右ジャンプ
            if (inputAxes.getAxes() == 9)
            {
                jumpForceVec = new Vector2(0.4f, 1);
            }

            //　左ジャンプ
            if (inputAxes.getAxes() == 7)
            {
                jumpForceVec = new Vector2(-0.4f, 1);
            }


            rb2d.velocity = jumpForceVec * charStatus.GetJumpPower();

            animator.PlayInFixedTime("Jump", 0);
        }
    }

    /// <summary>
    /// 移動制御
    /// </summary>
    void MovementControl()
    {
        isRecession = false;
        isAdvance = false;

        //　後方移動
        if (inputAxes.getAxes() == 4)
        {
            //　左向き
            if (regularDirec)
            {
                isRecession = true;
            }
            else
            {
                isAdvance = true;
            }

            if (!isCrouch || !EnableGuard)
                moveVel.x = -1;
        }

        //　前方移動
        if (inputAxes.getAxes() == 6)
        {
            if (regularDirec)
            {
                isAdvance = true;
            }
            else
            {
                isRecession = true;
            }

            if (!isCrouch || !EnableGuard)
                moveVel.x = 1;
        }

        animator.SetBool("Recession", isRecession);
        animator.SetBool("Advance", isAdvance);

        moveVel.x = moveVel.x * charStatus.GetMoveSpeed() * Time.deltaTime;

    }

    /// <summary>
    /// しゃがみ制御
    /// </summary>
    void CrouchControl()
    {
        isCrouch = false;

        //　しゃがみ
        if (inputAxes.getAxes() == 2 ||
            inputAxes.getAxes() == 3 ||
            inputAxes.getAxes() == 1)
        {
            isCrouch = true;
        }

        animator.SetBool("Crouch", isCrouch);

    }

    void GuardController()
    {
        EnableGuard = false;

        //　向き
        if (regularDirec)
        {
            if (inputAxes.getAxes() == 4 ||
                inputAxes.getAxes() == 1)
            {
                EnableGuard = true;
            }

        }
        else
        {
            if (inputAxes.getAxes() == 6 ||
                inputAxes.getAxes() == 3)
            {
                EnableGuard = true;

            }
        }

        animator.SetBool("Gurad", EnableGuard);

    }

    public bool getAttack()
    {
        return isAttack;
    }

}
