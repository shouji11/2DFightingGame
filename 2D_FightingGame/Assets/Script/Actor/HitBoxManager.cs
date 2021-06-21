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

//player1かplayer2か
public enum GroupType {

    Player1,
    Player2,

}

public class HitBoxManager : MonoBehaviour
{
    HitType hitType = HitType.None;
    private GameObject player1, player2;
    GameObject HB_Attack, HB_Damage;

    private const string AttackTag = "Attack";
    private const string PushingTag = "Pushing";
    private const string DamageTag = "Damage";

    AttackDealer attackDealer;
    DamageDealer damageDealer;
    PushingBox pushingBox;


    private void Start()
    {
        
    }

    private void Update()
    {
        
    }





}