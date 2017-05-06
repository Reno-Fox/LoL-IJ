using UnityEngine;
using UnityEngine.UI;
using System;

[Serializable]
public class Click : MonoBehaviour {

    public Text goldPerClickText;
    public Text goldDisplayText;

    public float totalGold = 0.00f; //super
    public int totalGoldPerClick = 1; //super

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
