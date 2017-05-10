using UnityEngine;
using UnityEngine.UI;
using System;

public class ClickManager : MonoBehaviour {

    public Text goldPerClickText;
    public Text goldDisplayText;

    public float totalGold = 0.00f; //super
    public float totalGoldPerClick = 1.0f; //super

    void Update()
    {
        goldDisplayText.text = "Gold: " + CurrencyConverter.Instance.GetCurrencyIntoString(totalGold,false, false);
        goldPerClickText.text = totalGoldPerClick + " gold/click";
    }

    public void Clicked()
    {
        totalGold += totalGoldPerClick;
    }

}
