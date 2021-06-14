using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMark2 : MonoBehaviour
{
    public GameObject image1, image2;
    private static Image markImage1_2p, markImage2_2p;

    private Sprite sprite1_2p, sprite2_2p, sprite3_2p, sprite4_2p;

    private static int judgeNum2, winCount2;

    /// <summary>
    /// スプライト読み込み
    /// </summary>
    public void LoadSprite()
    {
        //　Resourcesフォルダからスプライトを読み込み   

        sprite1_2p = Resources.Load<Sprite>("UI\\VictoryIcon");
        sprite2_2p = Resources.Load<Sprite>("UI\\TimeOverIcon");
        sprite3_2p = Resources.Load<Sprite>("UI\\DoubleKoIcon");
        sprite4_2p = Resources.Load<Sprite>("UI\\ground1");

        markImage1_2p = image1.GetComponent<Image>();
        markImage2_2p = image2.GetComponent<Image>();

    }

    public void getWinMark(int wincount, int judgenum)
    {
        judgeNum2 = judgenum;
        winCount2 = wincount;

        SetImage_2p();

        if (judgeNum2 == 0)
        {
            markImage1_2p.sprite = sprite4_2p;
            markImage2_2p.sprite = sprite4_2p;

        }

    }

    /// <summary>
    /// 勝利マーク付属
    /// </summary>
    public void SetImage_2p()
    {
        if (winCount2 == 1)
        {
            if (judgeNum2 == 2)
            {
                markImage1_2p.sprite = sprite1_2p;
            }
            else if (judgeNum2 == 3)
            {
                markImage1_2p.sprite = sprite2_2p;
            }
            else if (judgeNum2 == 5)
            {
                markImage1_2p.sprite = sprite2_2p;
            }
            else if (judgeNum2 == 6)
            {
                markImage1_2p.sprite = sprite3_2p;
            }

        }
        else if (winCount2 == 2)
        {
            if (judgeNum2 == 2)
            {
                markImage2_2p.sprite = sprite1_2p;
            }
            else if (judgeNum2 == 3)
            {
                markImage2_2p.sprite = sprite2_2p;
            }
            else if (judgeNum2 == 5)
            {
                markImage2_2p.sprite = sprite2_2p;
            }
            else if (judgeNum2 == 6)
            {
                markImage2_2p.sprite = sprite3_2p;
            }
        }

    }

    /// <summary>
    /// 勝利マークをリセット
    /// </summary>
    public static void resetP2WinMark()
    {
        winCount2 = 0;
        judgeNum2 = 0;
    }

}
