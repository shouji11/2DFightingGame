using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Command2 : MonoBehaviour
{
    private static int keyNum;
    private int oldKey;

    private float inputTime = 0.0f;


    public int getAxes()
    {
        int axes = 5;


        if (Input.GetAxisRaw("Vertical2") > 0.9)
        {
            if (Input.GetAxisRaw("Horizontal2") > 0.9)
            {
                axes = 9;
                countFrame();
            }           
            else if (Input.GetAxisRaw("Horizontal2") == 0)
            {
                axes = 8;
                countFrame();

            }
            else if (Input.GetAxisRaw("Horizontal2") < -0.9)
            {
                axes = 7;
                countFrame();

            }
        }

        if (Input.GetAxisRaw("Vertical2") == 0)
        {
            if (Input.GetAxisRaw("Horizontal2") > 0.9)
            {
                axes = 6;
                countFrame();

            }
            else if (Input.GetAxisRaw("Horizontal2") == 0)
            {
                axes = 5;
                countFrame();

            }
            else if (Input.GetAxisRaw("Horizontal2") < -0.9)
            {
                axes = 4;
                countFrame();

            }
        }

        if (Input.GetAxisRaw("Vertical2") < -0.9)
        {
            if (Input.GetAxisRaw("Horizontal2") > 0.9)
            {
                axes = 3;
                countFrame();

            }
            else if (Input.GetAxisRaw("Horizontal2") == 0)
            {
                axes = 2;
                countFrame();

            }
            else if (Input.GetAxisRaw("Horizontal2") < -0.9)
            {
                axes = 1;
                countFrame();

            }
        }


        return axes;
    }

    public void getAttackInput()
    {
        if (Input.GetButton("Attack_A_2") )
        {

        }
        if (Input.GetButton("Attack_B_2"))
        {

        }
        if (Input.GetButton("Attack_C_2"))
        {

        }
    }

    float countFrame()
    {
        inputTime = 0.0f;

        return inputTime += Time.deltaTime;

    }


}
