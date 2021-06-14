using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    const float MinCount = 0;
    
    public static float MaxCount;
    public int count;
    private bool timerStart;

    public Text timerText;
    public GameObject gameObject;
    private GameScene gameScene;

    
    // Start is called before the first frame update
    void Start()
    {
        timerText = GetComponent<Text>();
        gameScene = gameObject.GetComponent<GameScene>();

        timerStart = false;
    }

    void Awake()
    {
        TimerReset();

    }

    // Update is called once per frame
    void Update()
    {     
        //ラウンドストップが発動していないとき
        //タイマーリセットがfalseの時
        if(timerStart)
        {
            if (MaxCount >= MinCount)
            {
                MaxCount -= Time.deltaTime;

                if (MaxCount <= MinCount)
                {
                    MaxCount = 0;
                }
            }
        }
        timerText.text = MaxCount.ToString("f0");
       
    }

    /// <summary>
    /// タイマーのリセット
    /// </summary>
    public void TimerReset()
    {
        MaxCount = count;
    }


    public bool GetZeroCount(float count)
    {
        bool zeroTimerFlag = false;

        if(count == 0)
        {
           zeroTimerFlag = true;
        }

        return zeroTimerFlag;
    }

    /// <summary>
    /// タイマースタート
    /// </summary>
    public void StartTimer()
    {
        timerStart = true;
    }

    /// <summary>
    /// タイマーストップ
    /// </summary>
    public void StopTimer()
    {
        timerStart = false;
    }

}
