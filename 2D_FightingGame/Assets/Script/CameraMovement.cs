using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{

    public GameObject player1, player2;

    private Transform player1_pos, player2_pos;
    private Camera camera;

    private float moveSpeed;

    private bool distOver = false;
    private float center;

    // Start is called before the first frame update
    void Start()
    {
        player1_pos = player1.GetComponent<Transform>();
        player2_pos = player2.GetComponent<Transform>();
        camera = GetComponent<Camera>();

        moveSpeed = 1f;
    }

    // Update is called once per frame
    void Update()
    {
        moveCamera();

    }

    void moveCamera()
    {
        const float moveEndX = 7.8f; //カメラの移動限界

        //画面の中心
        center = (player2_pos.transform.position.x +
            player1_pos.transform.position.x) /2;

        //カメラの移動
        transform.position = new Vector3(center * moveSpeed, -1.51f, -10);

        //カメラが端についた
        if(transform.position.x <= -moveEndX)
        {
            transform.position = new Vector3(-moveEndX, -1.51f,-10);
        }
        else if (transform.position.x >= moveEndX)
        {
            transform.position = new Vector3(moveEndX, -1.51f, -10);
        }
        
    }

    void CameraZoom()
    {        
        //プレイヤー間の距離
        float distx = (player2_pos.transform.position.x- 
            player1_pos.transform.position.x);
               
        float view = camera.fieldOfView - distx;

        camera.fieldOfView = view;

    }

    /// <summary>
    /// 演出(勝利時勝った側に移動する)
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
    
