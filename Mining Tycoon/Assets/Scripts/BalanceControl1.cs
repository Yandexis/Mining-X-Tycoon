using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceControler : MonoBehaviour
{
    //переменная деньги
    public static int MoneyValue;
    //текст блок на который выводится MoneyValue
    private Text TextValue;

    void Start()
    {
        //получаем компонент Text
        TextValue = GetComponent<Text>();
        MoneyValue = 0;
    }

    void FixedUpdate()
    {
        //выводим в Text группы MoneyBlock количество денег
        TextValue.text = $"{MoneyValue}";
    }
}
