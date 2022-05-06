using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController1 : MonoBehaviour
{
    private bool isGraund;        //着地してるか
    private bool regularDirec;      //正規向き　true = 右向き、false = 左向き
    private bool isCrouch = false;      //しゃがみ
    private bool controller = false;    //　コントロール
    bool EnableGuard = false; //ガード
    bool isAttack = false;　　//
    const string ObjName = "Player";
    
    [SerializeField] Animator animator;      //アニメーション
    [SerializeField] Command1 inputAxes;
    private Vector3 moveVel;
    private Rigidbody2D rb2d;
    private CharacterStatus charStatus;
    private CharacterControl charControl;
    private Vector2 jumpForceVec; //ジャンプ
    ColliderContoller P2_control;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2d = GetComponent<Rigidbody2D>();
        charStatus = GameObject.Find(ObjName).GetComponent<CharacterStatus>();
        charControl = GameObject.Find(ObjName).GetComponent<CharacterControl>();
        P2_control = GameObject.Find("Player2").GetComponent<ColliderContoller>();

    }

    // Update is called once per frame
    void Update()
    {
        controller = charControl.GetController();

        if (!controller) return;
        regularDirec = charControl.PlayerDirection();

        if (charControl.IsGraund())
        {
            GuardController();

            charControl.PlayerFlip();

            JumpControl();

            CrouchControl();

        }

        AttackControl();
        charControl.DamageControl();
        charControl.DownControl();
    }
    private void FixedUpdate()
    {
        if (!controller) return;

        if (charControl.IsGraund())
        {
            MovementControl();
        }

        transform.position += moveVel;
        charControl.PlayerInScreen();

    }

    /// <summary>
    /// 攻撃制御
    /// </summary>
    void AttackControl()
    {
        if (Input.GetButtonDown("Attack_A_1"))
        {
            animator.SetTrigger("Attack_A");
            isAttack = true;
        }

        //　中攻撃
        if (Input.GetButtonDown("Attack_B_1"))
        {
            animator.SetTrigger("Attack_B");
            isAttack = true;
        }

        //　強攻撃
        if (Input.GetButtonDown("Attack_C_1"))
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
                jumpForceVec = new Vector2(0,1);
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
        bool isRecession = false;   //後退
        bool isAdvance = false;     //前進
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

    /// <summary>
    /// ガード制御
    /// </summary>
    void GuardController()
    {
        EnableGuard = false;

        //　向き
        if (regularDirec)
        {
            if (inputAxes.getAxes() == 4 ||
                inputAxes.getAxes() == 1)
            {
                if (P2_control.getIsAttack())
                    EnableGuard = true;
            }
           
        }
        else
        {
            if (inputAxes.getAxes() == 6 ||
                inputAxes.getAxes() == 3)
            {
                if (P2_control.getIsAttack())
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
