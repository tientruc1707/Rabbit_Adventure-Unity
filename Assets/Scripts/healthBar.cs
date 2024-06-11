using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class healthBar : MonoBehaviour
{
    public Slider HpSlider;
    public Slider EaseHpSlider;
    public float MaxHp = 100f;
    public float HpValue ;
    // Start is called before the first frame update
    void Start()
    {
        HpValue = MaxHp;
    }

    // Update is called once per frame
    void Update()
    {
        if(HpSlider.value != HpValue) 
        {
            HpSlider.value = HpValue;
        }
        if(Input.GetKeyDown(KeyCode.Space)) {
            HpValue -= 10;
        }
        if(HpSlider.value != EaseHpSlider.value)
        {
            EaseHpSlider.value = Mathf.Lerp(EaseHpSlider.value, HpValue, Time.deltaTime);
        }
    }
}
