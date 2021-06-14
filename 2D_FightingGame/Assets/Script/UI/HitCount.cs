using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HitCount : MonoBehaviour
{
    private int Count = 0;
    private float countStopTime;

    public Image hitCountImage, hitImage;

    private bool countStart; //カウント開始



    // Start is called before the first frame update
    void Start()
    {
        hitCountImage.GetComponent<Image>();
        hitImage.GetComponent<Image>();
    }

    // Update is called once per frame
    void Update()
    {


    }

    void comboCounter()
    {
        if (!countStart) return;

        

    }

    public void comboStart()
    {
        countStart = true;
    }



}
