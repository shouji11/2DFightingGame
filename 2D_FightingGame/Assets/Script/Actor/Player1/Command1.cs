using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//どっちのプレイヤーのコントロールするか
public enum Player_Controls
{
    Note,
    Player1,
    Player2
}


public class Command1 : MonoBehaviour
{
    public Player_Controls Player = Player_Controls.Note;

    int axes;
    bool onAttack_A, onAttack_B, onAttack_C;
    private string controls;
    //private int frameCount;
    //private List<int> command = new List<int>();
   
    public void Init()
    {
        controls = Player.ToString(); //
        onAttack_A = false;
        onAttack_B = false;
        onAttack_C = false;

    }

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
    
    public Player_Controls GetPlayer_Contral()
    {
        return Player;
    }

}
