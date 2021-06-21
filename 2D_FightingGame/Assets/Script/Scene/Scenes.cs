using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Scene {

    Taitle,
    CharacterSelect,
    GamePlay,

}

// シーンマネージャークラス
public class Scenes : MonoBehaviour
{
    Scene scene = Scene.Taitle;

    const string title = "Title";
    const string game = "GamePlay";


    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
