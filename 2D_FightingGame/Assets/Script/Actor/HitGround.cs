using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitGround : MonoBehaviour
{
    private const string taggraund = "ground";
    private bool isGraund = false;


    public bool IsGround()
    {       
        return isGraund;
    }


    void OnTriggerEnter2D(Collider2D collider2D)
    {
        if (collider2D.tag ==taggraund)
        {
            isGraund = true;

        }
    }

    void OnTriggerStay2D(Collider2D collider2D)
    {
        if (collider2D.tag == taggraund)
        {
            isGraund = true;
        }
    }

    void OnTriggerExit2D(Collider2D collider2D)
    {
        if (collider2D.tag == taggraund)
        {
            isGraund = false;
        }
    }
}
