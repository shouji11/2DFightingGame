using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CharacterSelect : MonoBehaviour
{
    //public GameObject characterPrefab; //　キャラクタープレハブ

    private bool playerSelect1, playerSelect2;

    private void Start()
    {
        playerSelect1 = false;
        playerSelect2 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameScene.resetProperty();

            //WinMark1.resetP1WinMark();
            //WinMark2.resetP2WinMark();

            NextScene();
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        
    }

    void NextScene()
    {
        //SceneManager.LoadScene(2, LoadSceneMode.Additive); //　追加ロード

        SceneManager.LoadScene(2); //　ステージセレクトへ
    }

}
