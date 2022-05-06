using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class GameScene : MonoBehaviour
{
    [SerializeField] PlayerHPGaugeUI vitality1P, vitality2P;
    [SerializeField] Timer timer;　//タイマー
    [SerializeField] WinMark1 winMark1;
    [SerializeField] WinMark2 winMark2;
    [SerializeField] GameObject player1, player2; //　プレイヤーオブジェ
    [SerializeField] GameObject koAnimeObj,timeoverAnimeObj,
        p1winAnimeObj, p2winAnimeObj;   //アニメオブジェ
    
    private CharacterControl cont1, cont2;
    private Animator animator, animator2, 
        p1animator, p2animator;

    public PlayableDirector RoundDirector1,
        RoundDirector2, RoundDirectorFinal; //　ラウンド演出
    private Fade fade;

    const int maxRound = 3; //最大ラウンド数
    private static int Round = 1; //現状のラウンド数
    private static bool RoundStopFlag; //どちらかもしくは両方の体力が0になったら 発動
    private static int player1winCount =0; //勝利数
    private static int player2winCount =0;
    private static int winnernum = 0; //勝者
    private bool nextSceneFlag; //次のシーン
    private bool roundStartFlag,waitJudgeFlag; //ラウンド開始 , 勝利判断
    private bool P1_WinFlag, P2_WinFlag, timeoverFlag;//1P勝利、2P勝利、タイムオーバー


    void Start()
    {
        cont1 = player1.GetComponent<CharacterControl>();
        cont2 = player2.GetComponent<CharacterControl>();
        animator = koAnimeObj.GetComponent<Animator>();
        animator2 = timeoverAnimeObj.GetComponent<Animator>();
        p1animator = p1winAnimeObj.GetComponent<Animator>();
        p2animator = p2winAnimeObj.GetComponent<Animator>();
        fade = GameObject.Find("Fade").GetComponent<Fade>();

        winMark1.LoadSprite();
        winMark2.LoadSprite();

        gameInit();
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //ラウンド開始フラグ
        if (roundStartFlag)
        {
            fade.startFade(2.3f, false); //フェードイン処理

            if (!fade.FadeEnd()) return; //フェード終了したら通過


            StartCoroutine(gameInitCoroutine());//初期化コルーチンを開始

            roundStartFlag = false; //ラウンドを開始する

        }

        //次のシーンフラグ
        if (nextSceneFlag)
        {
            fade.startFade(2.3f, true); //フェード開始

            if (!fade.FadeEnd()) return; 

            //　ラウンドがFinalに達成もしくは
            //　1p2pどちらか2本先取したとき
            if ((Round == maxRound) ||
               (player1winCount == 2) ||
               (player2winCount == 2))
            {
                //次のシーン
                NextScene();
            }
            else if (!(Round == maxRound))
            {
                //　次のラウンド
                NextRound();
            }
            
        }


        if(RoundStop())
        {
            StartCoroutine(gameFlowCoroutine());
        }

    }

    //　ゲームシーンコルーチン
    IEnumerator gameInitCoroutine()
    {
        //　ラウンド演出
        RoundDirection(Round);

        yield return new WaitForSeconds(2.0f);

        //　タイマースタート
        timer.StartTimer();

        //　キャラクターの操作を行えるようにする
        cont1.EnableController();
        cont2.EnableController();

        yield return null;
    }
    
    IEnumerator gameFlowCoroutine()
    {
        //　KO演出
        KoDirection();
        //タイムオーバー演出
        TimeOverDirection();
        //　1p2pのコントロールを無効にする
        cont1.DisableController();
        cont2.DisableController();

        yield return new WaitForSeconds(2.0f);

        if (waitJudgeFlag)
        {
            //　勝利判断
            WinJudge();
            waitJudgeFlag = false;
        }

        // 勝利演出
        WinDirection();
        yield return new WaitForSeconds(1.5f);


        winMark1.getWinMark(player1winCount, winnernum);
        winMark2.getWinMark(player2winCount, winnernum);

        yield return new WaitForSeconds(2.0f);

        nextSceneFlag = true;

    }

    void gameInit()
    {
        //　コントロールの無効
        cont1.DisableController();
        cont2.DisableController();

        RoundStopFlag = false;
        nextSceneFlag = false;

        fade.InitFade(); //フェード初期化

        winMark1.SetImage_1p();
        winMark2.SetImage_2p();

        //　キャラクターの体力のセット
        vitality1P.PlayerVitalitySet();
        vitality2P.PlayerVitalitySet();

        
        //ラウンド演出PlayableDirectorの無効
        RoundDirector1.enabled = false;
        RoundDirector2.enabled = false;
        RoundDirectorFinal.enabled = false;

        roundStartFlag = true; 
        waitJudgeFlag = true; //勝利判断を1回だけ通る用

    }
    

    /// <summary>
    /// ラウンドを止める
    /// </summary>
    /// <returns></returns>
    public bool RoundStop()
    {

        //タイマーが0もしくは、どちらかの体力が0になったら
        if (timer.GetZeroCount(Timer.MaxCount) ||
            vitality1P.GetVitalityValue() <= 0 ||
            vitality2P.GetVitalityValue() <= 0)
        {
            RoundStopFlag = true;
            roundStartFlag = false;
            timer.StopTimer();

            if (timer.GetZeroCount(Timer.MaxCount))
            {
                timeoverFlag = true;
            }
            else if (vitality2P.GetVitalityValue() <= 0)
            {
                P1_WinFlag = true;
            }
            else if (vitality1P.GetVitalityValue() <= 0)
            {
                P2_WinFlag = true;
            }

        }

        return RoundStopFlag;
    }

    /// <summary>
    /// ラウンド演出
    /// </summary>
    /// <param name="round">現在のラウンド</param>
    void RoundDirection(int round)
    {
        switch(round)
        {
            case 1:
                RoundDirector1.enabled = true;

                RoundDirector1.Play();
                
                return;

            case 2:
                RoundDirector2.enabled = true;
                
                RoundDirector2.Play();

                return;

            case 3:
                RoundDirectorFinal.enabled = true;

                RoundDirectorFinal.Play();

                return;
        }
        
    }

    /// <summary>
    /// KO演出
    /// </summary>
    void KoDirection()
    {
        if(P1_WinFlag || P2_WinFlag)
        {
            koAnimeObj.SetActive(true);

            animator.SetBool("KO", RoundStopFlag);

        }
    }

    /// <summary>
    /// タイムオーバー演出
    /// </summary>
    void TimeOverDirection()
    {
        if (timeoverFlag)
        {
            timeoverAnimeObj.SetActive(true);

            animator2.SetBool("TimeOver", RoundStopFlag);
        }
    }

    /// <summary>
    /// 次のラウンド
    /// </summary>
    void NextRound()
    {
        Round = Round + 1;
        SceneManager.LoadScene(1);//gameSceneへ
    }

    /// <summary>
    /// 次のシーン
    /// </summary>
    void NextScene()
    {
        SceneManager.LoadScene("Title");

    }

    /// <summary>
    /// 勝利判断
    /// </summary>
    /// <returns></returns>
    void WinJudge()
    {                
        if (P1_WinFlag)  //　2p側の体力が0
        {
            winnernum = 1;
            player1winCount = player1winCount + 1;

        }
        else if(P2_WinFlag) //　1p側の体力が0
        {
            winnernum = 2;
            player2winCount = player2winCount + 1;

        }

        //　タイマーが0の時
        if (timeoverFlag)
        {
            if (vitality1P.GetVitalityValue() ==
                vitality2P.GetVitalityValue()) //　お互いの体力が一緒だったら
            {
                winnernum = 3;
                player1winCount = player1winCount + 1;
                player2winCount = player2winCount + 1;

            }
            else if (vitality1P.GetVitalityValue() >
                     vitality2P.GetVitalityValue())  //　1p側の体力が2p側より多かったら
            {
                winnernum = 4;
                player1winCount = player1winCount + 1;

            }
            else if (vitality1P.GetVitalityValue() <
                     vitality2P.GetVitalityValue()) //　2p側の体力が1pより多かったら
            {
                winnernum = 5;
                player2winCount = player2winCount + 1;
            }
        }            
        
        //　お互い体力0
        if(vitality1P.GetVitalityValue() <= 0 &&
            vitality2P.GetVitalityValue() <= 0)
        {
            winnernum = 6;
            player1winCount = player1winCount + 1;
            player2winCount = player2winCount + 1;

        }

    }

    /// <summary>
    /// 勝利演出
    /// </summary>
    void WinDirection()
    {

        if (P1_WinFlag)
        {
            p1winAnimeObj.SetActive(true);

            p1animator.SetBool("1pwin", P1_WinFlag);
        }
        else if (P2_WinFlag)
        {
            p2winAnimeObj.SetActive(true);

            p2animator.SetBool("2pwin", P2_WinFlag);
        }

        //　カメラを勝者側に移動
        //cameraMovement.Direction(P1_Win,P2_Win);
    }
    
    /// <summary>
    /// リセット
    /// </summary>
    public static void resetProperty()
    {
        player1winCount = 0;
        player2winCount = 0;
        Round = 1;
        RoundStopFlag = false;
        WinMark1.resetP1WinMark();
        WinMark2.resetP2WinMark();

    }


}
