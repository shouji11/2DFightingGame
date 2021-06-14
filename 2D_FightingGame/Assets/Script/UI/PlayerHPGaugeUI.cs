using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerHPGaugeUI : MonoBehaviour
{
    //private static int vitalityValue1P = 0;

    private int vitalityValue = 0;

    public string myVitalityName;
    public Slider myVitalitySlider;

    [SerializeField]
    private CharacterStatus playerStatus;

    [SerializeField]
    private DamageDealer damageDealer, damageDealer2;

    //　攻撃判定を食らったか
    private bool isHitAttack, isHitAttack2;
    

    // Start is called before the first frame update
    void Start()
    {
        myVitalitySlider = GameObject.Find(myVitalityName).GetComponent<Slider>();

        //スライダーの値に体力ゲージの値を代入
        myVitalitySlider.maxValue = PlayerVitalitySet();

    }

    void Update()
    {
        HitBoxDiscrimination();

        //GaugeUiImage();

    }

    void HitBoxDiscrimination()
    {
        isHitAttack = damageDealer.IsHitDamage();
        isHitAttack2 = damageDealer2.IsHitDamage();

        if (isHitAttack || isHitAttack2)
        {
            vitalityValue -= 20;

            // vitalityGaugeが 0 以下になったら
            if (vitalityValue <= myVitalitySlider.minValue)
            {
                vitalityValue = (int)myVitalitySlider.minValue;
                //zeroVita = true;
            }
            
        }
        
        myVitalitySlider.value = vitalityValue;

    }

    void GaugeUiImage()
    {
        if (myVitalitySlider.value == myVitalitySlider.maxValue)
        {
           // image.color = new Color(0.0f, 255.0f, 65.0f, 1.0f);
        }
        else
        {
           // image.color = new Color(240.0f, 255.0f, 65.0f, 1.0f);
        }

    }


    public int PlayerVitalitySet()
    {
        return vitalityValue = playerStatus.GetVitality();

    }

    public int GetVitalityValue()
    {
        return vitalityValue;
    }

}
