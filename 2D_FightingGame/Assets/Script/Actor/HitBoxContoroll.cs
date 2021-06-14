using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum HitType
{
    None = 0,
    Pushing,        //　押し合い
    Damage,         //　やられ・くらい
    Attack,         //　攻撃
    Guard,          //　ガード
}

public enum ColliderColor
{
    RED,
    GREEN,
    BLUE,
    YELLOW,

}

//player1かplayer2か
public enum GroupType {

    Player1,
    Player2

}

public class HitBoxContoroll 
{
    public ColliderColor colliderColor = ColliderColor.GREEN;
    [SerializeField] GroupType group;

    private Color DebugColliderLineColor;
    
    
    private GameObject opponetObj;
    private LineRenderer lineRenderer;

    private const string AttackTag = "Attack";
    private const string PushingTag = "Pushing";
    private const string DamageTag = "Damage";
 

    Color DebugColliderColor()
    {
        Color color = Color.green;


        switch (colliderColor) {

            case ColliderColor.BLUE:

                return color = Color.blue;

            case ColliderColor.GREEN:
                return color = Color.green;

            case ColliderColor.RED:
                return color = Color.red;

            case ColliderColor.YELLOW:
                return color = Color.yellow;

        }

        return color;

    }
    
}