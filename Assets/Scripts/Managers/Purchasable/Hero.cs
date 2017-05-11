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

    public Color standard;
    public Color affordable;

    void Start()
    {
        count = 0;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost " + goldCost + "\nGold: " + clickRate + "/s";

        if (Game.Instance.clickManager.totalGold >= goldCost)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
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
