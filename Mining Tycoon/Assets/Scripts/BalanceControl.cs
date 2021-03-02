using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BalanceControl : MonoBehaviour
{
    //переменная деньги
    public int MoneyValue;
    //текст блок на который выводится MoneyValue
    public Text TextValue;

    void Start()
    {
        MoneyValue = 0;
    }

    void FixedUpdate()
    {
        //выводим в Text группы MoneyBlock количество денег
        TextValue.text = $"{MoneyValue}";
    }
}
