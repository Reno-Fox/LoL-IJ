using UnityEngine;
using UnityEngine.UI;
using System;

public class Hero : MonoBehaviour
{
    public string itemName;
    public Text itemInfo;

    public float goldCost;
    public int count;

    public int clickRate;

    public float damagePerSecond;

    public Color affordable;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        if (Game.Instance.clickManager.totalGold >= goldCost)
        {
            itemInfo.text = itemName + "\nCost " + goldCost + "\nGold: " + clickRate + "/sec";
            GetComponent<Image>().color = affordable;
        }
        else
        {
            itemInfo.text = "";
            GetComponent<Image>().color = new Color(affordable.r, affordable.g, affordable.b, 0.5f);
        }
    }

    public void PurchasedHero()
    {
        if (Game.Instance.clickManager.totalGold >= goldCost)
        {
            Game.Instance.clickManager.totalGold -= goldCost;
            count += 1;
            goldCost = Mathf.Round(goldCost * Mathf.Pow(Settings.PurchaseIncreaseRate, count));
        }
    }

}
