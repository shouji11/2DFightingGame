using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinMark1 : MonoBehaviour
{
    public GameObject image1, image2;
    private static Image markImage1_1p, markImage2_1p;

    private Sprite sprite1_1p,sprite2_1p,sprite3_1p,sprite4_1p;

    private static int judgeNum, winCount;

    /// <summary>
    /// スプライト読み込み
    /// </summary>
    public void LoadSprite()
    {
        //　Resourcesフォルダからスプライトを読み込み   
        sprite1_1p = Resources.Load<Sprite>("UI\\VictoryIcon");
        sprite2_1p = Resources.Load<Sprite>("UI\\TimeOverIcon");
        sprite3_1p = Resources.Load<Sprite>("UI\\DoubleKoIcon");
        sprite4_1p = Resources.Load<Sprite>("UI\\ground1");

        markImage1_1p = image1.GetComponent<Image>();
        markImage2_1p = image2.GetComponent<Image>();

    }
    
    public void getWinMark(int wincount,int judgenum)
    {
        judgeNum = judgenum;
        winCount = wincount;

        SetImage_1p();

        if (judgeNum == 0)
        {
            markImage1_1p.sprite = sprite4_1p;
            markImage2_1p.sprite = sprite4_1p;
        }
        
    }

    /// <summary>
    /// 勝利マーク付属
    /// </summary>
    public void SetImage_1p()
    {
        if (winCount == 1)
        {
            if (judgeNum == 1)
            {
                markImage1_1p.sprite = sprite1_1p;
            }
            else if (judgeNum == 3)
            {
                markImage1_1p.sprite = sprite2_1p;

            }
            else if (judgeNum == 4)
            {
                markImage1_1p.sprite = sprite2_1p;

            }
            else if (judgeNum == 6)
            {
                markImage1_1p.sprite = sprite3_1p;

            }

        }
        else if (winCount == 2)
        {
            if (judgeNum == 1)
            {
                markImage2_1p.sprite = sprite1_1p;
            }
            else if (judgeNum == 3)
            {
                markImage2_1p.sprite = sprite2_1p;

            }
            else if (judgeNum == 4)
            {
                markImage2_1p.sprite = sprite2_1p;

            }
            else if (judgeNum == 6)
            {
                markImage2_1p.sprite = sprite3_1p;

            }

        }
        
    }

    /// <summary>
    /// 勝利マークをリセット
    /// </summary>
    public static void resetP1WinMark()
    {
        winCount = 0;
        judgeNum = 0;
    }

}
