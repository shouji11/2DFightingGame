using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    private bool isFade = false; //フェードするかどうか

    public float fadeTime; //フェードにかかる時間

    public bool isFadeOut; //

    private Image image;

    // Start is called before the first frame update
    void Start()
    {
        InitFade();
    }

    public void InitFade()
    {
        image = GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isFade)
        {
            if (isFadeOut)
            {
                //フェードアウト
                if(image.color.a <= 1)
                {
                    image.color = new Color(0, 0, 0, 
                        image.color.a + 1 / (60 * fadeTime));
                }
                else
                {
                    isFade = false;
                }
           
            }
            else
            {
                //フェードイン
                if (image.color.a >= 0)
                {
                    image.color = new Color(0, 0, 0,
                        image.color.a - 1 / (60 * fadeTime));
                }
                else
                {
                    isFade = false;
                }

            }
        }
    }

    /// <summary>
    /// フェード開始
    /// </summary>
    /// <param name="t">時間</param>
    /// <param name="fadeout">true:フェードアウト、false:フェードイン</param>
    public void startFade(float t, bool fadeout)
    {
        fadeTime = t;

        isFadeOut = fadeout ? true : false;

        if (!isFade)
        {
            if (isFadeOut)
            {
                image.color = new Color(0, 0, 0, 0);
            }
            else
            {
                image.color = new Color(0, 0, 0, 1);
            }
        }
        
        isFade = true;
    }

    public bool FadeEnd()
    {
        if (isFadeOut)
        {
            if(image.color.a >= 1)
            {
                isFadeOut = false;
                isFade = false;
                return true;
            }
        }
        else
        {
            if (image.color.a <= 0)
            {
                isFadeOut = true;
                isFade = false;
                return true;
            }
        }

        return false;
    }

}
