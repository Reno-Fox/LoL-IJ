using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using System;

public class ItemManager : MonoBehaviour { 

    public Text goldPerSecondText;

    public List<Item> items;

    void Update()
    {
        goldPerSecondText.text = CaculateGoldPerSecond() + "gold/sec";
    }

    //Caculate the gold per second for all items purchased
    public float CaculateGoldPerSecond()
    {
        float tick = 0;
        foreach (Item item in items)
        {
            tick += item.count * item.clickRate;
        }
        return tick;
    }
}
