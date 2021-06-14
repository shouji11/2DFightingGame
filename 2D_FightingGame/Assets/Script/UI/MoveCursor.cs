using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveCursor : MonoBehaviour
{
    private int selectAriaNum = 5;
    private Vector2[] CursorAria = new Vector2[5];
    int n = 0;


    // Start is called before the first frame update
    void Start()
    {
        gameObject.transform.position = CursorAria[0];


        CursorAria[0] = new Vector2(-6.07f, -2.89f);
        CursorAria[1] = new Vector2(-2.12f, -2.89f);
        CursorAria[2] = new Vector2( 1.98f, -2.89f);
        CursorAria[3] = new Vector2( 5.86f, -2.89f);
        CursorAria[4] = new Vector2( 1.01f, -2.89f);

    }

    // Update is called once per frame
    void Update()
    {

        if (n < 0) n = 0;
        if (n > 4) n = 4;

        if(Input.GetKeyDown(KeyCode.LeftArrow))
        {
            n = n- 1;

        }

        if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            n = n + 1;
        }

        gameObject.transform.position = CursorAria[n];

        //Debug.Log(CursorAria[n]);
        
    }





}
