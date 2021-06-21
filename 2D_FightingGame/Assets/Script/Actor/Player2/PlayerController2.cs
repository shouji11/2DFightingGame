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

    private int attackTypeNum = 0;       //　攻撃したときの属性番号　0:攻撃してない、
                                         //　1:上段、2:中段、3:下段

    public Animator animator;      //アニメーション
    private Rigidbody2D rb2d;
    private CharacterStatus charStatus;
    private CharacterControl characterControl;

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

    }

    // Update is called once per frame
    void Update()
    {
        controller = characterControl.GetController();

        if (!controller) return;

        regularDirec = characterControl.PlayerDirection();

        if (characterControl.IsGraund())
        {

            JumpControl();

            characterControl.PlayerFlip();

            CrouchControl();

        }

        AttackControl();
        characterControl.DamageControl();
        characterControl.DownControl();
        
    }

    private void FixedUpdate()
    {
        if (!controller) return;

        if (characterControl.IsGraund())
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
            isAttack = true;
        }

        //　中攻撃
        if (Input.GetButtonDown("Attack_B_2"))
        {
            animator.SetTrigger("Attack_B");
            isAttack = true;
        }

        //　強攻撃
        if (Input.GetButtonDown("Attack_C_2"))
        {
            animator.SetTrigger("Attack_C");
            isAttack = true;
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

            isGraund = false;
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

            if (!isCrouch)
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

            if (!isCrouch)
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

    /// <summary>
    /// ガード反応距離
    /// </summary>
    bool EnableGuardReactionDist()
    {
        bool enableGuardMotion = false;

        //　自分と相手の距離
        float Distance = transform.position.x -
            GameObject.Find("Player").transform.position.x;

        if (Distance > -2)
        {
            enableGuardMotion = true;
        }

        return enableGuardMotion;
    }

    void guardController()
    {
        PlayerController1 controller = 
            GameObject.Find("Player").GetComponent<PlayerController1>();

        if (!controller.getAttack()) return;
        //　向き
        if (regularDirec)
        {
            if (inputAxes.getAxes() == 4)
            {
                EnableGuard = true;
            }
            else
            {
                EnableGuard = false;
            }

        }
        else
        {
            if (inputAxes.getAxes() == 6)
            {
                EnableGuard = true;

            }
            else
            {
                EnableGuard = false;
            }
        }

        animator.SetBool("Gurad", EnableGuard);

    }

    public bool getAttack()
    {
        return isAttack;
    }

}
