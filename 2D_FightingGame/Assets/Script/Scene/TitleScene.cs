using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TitleScene : MonoBehaviour
{
    private Fade fade;
    private bool nextScene;
    // Start is called before the first frame update
    void Start()
    {
        fade = GameObject.Find("Fade").GetComponent<Fade>();
        Resources.UnloadUnusedAssets();

        fade.InitFade();
        nextScene = false;
        fade.startFade(2.3f, false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            fade.startFade(2.3f, true);
            nextScene = true;
         
        }

        if (nextScene)
        {
            if (fade.FadeEnd())
            {
                GameScene.resetProperty();
                SceneManager.LoadScene("GamePlay");

            }
        }

        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    
    
}
