using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ItemManager : MonoBehaviour
{
    public Click click;
    public Text goldPerSecondText;

    public Item[] items;

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
