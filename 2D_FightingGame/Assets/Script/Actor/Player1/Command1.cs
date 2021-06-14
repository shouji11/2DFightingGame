using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command1 : MonoBehaviour
{
    //private static int keyNum;
    //private int oldKey;

    private int frameCount;
    int axes;
    bool onAttack_A, onAttack_B, onAttack_C;
    private List<int> command = new List<int>();


    /// <summary>
    /// 方向キー傾き(テンキー読み)
    /// </summary>
    /// <returns> </returns>
    public int getAxes()
    {

        if (Input.GetAxisRaw("Vertical1") > 0.9)
        {
            if (Input.GetAxisRaw("Horizontal1") > 0.9)
            {
                axes = 9;
            }           
            else if (Input.GetAxisRaw("Horizontal1") == 0)
            {
                axes = 8;

            }
            else if (Input.GetAxisRaw("Horizontal1") < -0.9)
            {
                axes = 7;
            }
        }

        if (Input.GetAxisRaw("Vertical1") == 0)
        {
            if (Input.GetAxisRaw("Horizontal1") > 0.9)
            {
                axes = 6;

            }
            else if (Input.GetAxisRaw("Horizontal1") == 0)
            {
                axes = 5;

            }
            else if (Input.GetAxisRaw("Horizontal1") < -0.9)
            {
                axes = 4;

            }
        }

        if (Input.GetAxisRaw("Vertical1") < -0.9)
        {
            if (Input.GetAxisRaw("Horizontal1") > 0.9)
            {
                axes = 3;

            }
            else if (Input.GetAxisRaw("Horizontal1") == 0)
            {
                axes = 2;

            }
            else if (Input.GetAxisRaw("Horizontal1") < -0.9)
            {
                axes = 1;

            }
        }


        return axes;
    }

    /// <summary>
    /// 攻撃ボタン入力
    /// </summary>
    public void getAttackInput()
    {
        if (Input.GetButton("Attack_A_1"))
        {
            onAttack_A = true;
        }

        if (Input.GetButton("Attack_B_1"))
        {
            onAttack_B = true;
        }

        if (Input.GetButton("Attack_C_1"))
        {
            onAttack_C = true;
        }

    }

    void countFrame()
    {



        //return frameCount = (int)Time.deltaTime;

    }

    void commands()
    {
       // if(axes )
        


    }


}
