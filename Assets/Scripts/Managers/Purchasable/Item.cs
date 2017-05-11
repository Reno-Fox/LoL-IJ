using UnityEngine;
using UnityEngine.UI;
using System;

public class Item : MonoBehaviour
{
    public string itemName;
    public Text itemInfo;

    public float goldCost;
    public float goldCostMultiplier;
    public int count;

    public int clickRate;

    public float damageBonus;

    public Color standard;
    public Color affordable;

    void Start()
    {
        count = 0;
        goldCost = goldCostMultiplier;
    }

    void Update()
    {
        itemInfo.text = itemName + "\nCost: " + goldCostMultiplier + "\n" + clickRate + "/gold click";

        if (Game.Instance.clickManager.totalGold >= goldCostMultiplier)
        {
            GetComponent<Image>().color = affordable;
        }
        else
        {
            GetComponent<Image>().color = standard;
        }
    }

    public void PurchaseItem()
    {
        if (Game.Instance.clickManager.totalGold >= goldCostMultiplier)
        {
            Game.Instance.clickManager.totalGold -= goldCostMultiplier;
            count += 1;
            Game.Instance.clickManager.totalGoldPerClick += clickRate;
            goldCostMultiplier = Mathf.Round(goldCost * Mathf.Pow(Settings.PurchaseIncreaseRate, count));
        }
    }
}
