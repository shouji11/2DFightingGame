using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public enum Scene {

    Note,
    Taitle,
    CharacterSelect,
    GamePlay,

}

// シーンマネージャークラス
public class Scenes : MonoBehaviour
{
    Scene scene = Scene.Note;

    const string title = "Title";
    const string game = "GamePlay";


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    void NextScene()
    {
        SceneManager.LoadScene(scene.ToString());
        return;
    }

}
