using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player1, player2;

    private Transform player1_pos, player2_pos;
    
    private float moveSpeed;

    private bool distOver = false;
    private float center;

    // Start is called before the first frame update
    void Start()
    {
        player1_pos = player1.GetComponent<Transform>();
        player2_pos = player2.GetComponent<Transform>();

        moveSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();
        //PlayersDist();

    }
       
    void moveCamera()
    {
        center = (player2_pos.transform.position.x +
            player1_pos.transform.position.x) /2;

        transform.position = new Vector3(center * moveSpeed, -1.51f, -10);

        //カメラが端についた
        if(transform.position.x <= -7.89f)
        {
            transform.position = new Vector3(-7.89f, -1.51f,-10);
        }
        else if (transform.position.x >= 7.94f)
        {
            transform.position = new Vector3(7.94f, -1.51f, -10);

        }
        
    }

    void PlayersDist()
    {
        //プレイヤー間の距離
        float distx = (player2_pos.transform.position.x- player1_pos.transform.position.x);
        const int designaDist = 11;

        //Debug.Log("距離" + distx);
        if (distx >= designaDist)
        {
            player1.transform.position = player1_pos.transform.position;
            player2.transform.position = player2_pos.transform.position;

            //transform.position = new Vector3(distx , -1.51f, -10);

        }

    }

    /// <summary>
    /// 演出用
    /// </summary>
    void Direction(bool p1,bool p2)
    {
        if(p1)
        {
            //center = player1_pos.transform.position.x;
            transform.position = new Vector3( 
                Easing.sineIn(5.0f,center, player1_pos.transform.position.x,50),
                -1.51f, -10);
        }
        else if(p2)
        {
            //center = player2_pos.transform.position.x;

            transform.position = new Vector3(
              Easing.sineIn(5.0f, center, player2_pos.transform.position.x, 50),
              -1.51f, -10);
        }
        else
        {
            return;
        }
        
    }



}
    
